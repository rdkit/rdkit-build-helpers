# Command line parameters:
# - dll should be RDKit2DotNet.dll
# - version is a version number in the format x.y.z.w (e.g, 2022.03.0.1 for a 2022.03 prerelease version)
# - snk is the path to a SNK file (can be generated with the sn.exe Visual Studio suite command)

param (
    [Parameter(Mandatory=$true)][string]$dll,
    [Parameter(Mandatory=$true)][string]$version,
    [Parameter(Mandatory=$true)][string]$snk
)

if (-Not (Test-Path $dll)) {
    throw ("Cannot access DLL $dll")
}
if (-Not (Test-Path $snk)) {
    throw ("Cannot access key pair $snk")
}
$dllPathInfo = Resolve-Path $dll
$dllDir = [System.IO.Path]::GetDirectoryName($dllPathInfo)
$dllBaseName = [System.IO.Path]::GetFileNameWithoutExtension($dllPathInfo)
$snkAbsPath = (Resolve-Path $snk).ToString()
$versionColonSeparated = $version -replace "\.", ":"
$arch = [System.Reflection.AssemblyName]::GetAssemblyName("${dllDir}\${dllBaseName}.dll").ProcessorArchitecture.ToString().ToLower()
$ilasmFlags = "/PE64 /X64"
if ($arch -Eq "x86") {
    $ilasmFlags = "/32BITPREFERRED"
} elseif ($arch -Eq "arm64") {
    $ilasmFlags = "/PE64 /ARM"
}

Push-Location $dllDir
Start-Process -Wait -FilePath cmd -ArgumentList "/c",
    "call `"${Env:ProgramFiles}\Microsoft Visual Studio\2022\Enterprise\VC\Auxiliary\Build\vcvars64.bat`" & cd $dllDir & ildasm ${dllBaseName}.dll /out:${dllBaseName}.il"

if (-Not (Test-Path "${dllBaseName}.dll.orig")) {
    Rename-Item "${dllBaseName}.dll" "${dllBaseName}.dll.orig"
}
$ilContent = Get-Content -Raw "${dllBaseName}.il"
$ilContent -replace "^([\s\S]+\.assembly\s+RDKit2DotNet\s+{[\s\S]+\.ver\s+)(\S+)(\s+[\s\S]+)$", "`${1}${versionColonSeparated}`${3}" | Set-Content "${dllBaseName}.il"
Start-Process -Wait -FilePath cmd -ArgumentList "/c",
    "call `"${Env:ProgramFiles}\Microsoft Visual Studio\2022\Enterprise\VC\Auxiliary\Build\vcvars64.bat`" & cd $dllDir & ilasm ${dllBaseName}.il $ilasmFlags /dll /key:${snkAbsPath}"
Pop-Location $dllDir
