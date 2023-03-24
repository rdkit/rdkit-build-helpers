# Windows

* Open `RDKitSimpleTest.sln` in Visual Studio
* To avoid incurring into package caching issues, if you want to be sure that
you are picking the latest RDKitDotNet package, select
Tools->NuGet Package Manager->Package Manager Settings
and click the "Clear All NuGet Storage" button 
* From Project->Manage NuGet packages, install the RDKitDotNet package
* Build->Build Solution
* The `RDKitSimpleTest\RDKitSimpleTest\bin\<X64|X86>\<Release|Debug>` directory
should now contain:
```
RDKFuncs.dll
RDKit2DotNet.dll
RDKitSimpleTest.exe
RDKitSimpleTest.exe.config
RDKitSimpleTest.pdb
```
* In a shell, run `RDKitSimpleTest\RDKitSimpleTest\bin\<X64|X86>\<Release|Debug>\RDKitSimpleTest.exe`

# Linux

* Install `mcs` and `mono`.
* In a shell, run the following commands:
```
$ cd RDKitSimpleTest/RDKitSimpleTest
$ ln -s ../../../../artifacts/RDKitDotNet/runtimes/lib-x64/net40/RDKit2DotNet.dll .
$ ln -s ../../../../artifacts/RDKitDotNet/runtimes/linux-x64/native/RDKFuncs.so RDKFuncs
$ mcs Program.cs /r:RDKit2DotNet.dll /out:RDKitSimpleTest.exe
$ LD_LIBRARY_PATH=$PWD mono RDKitSimpleTest.exe
```

# macOS

* Install Mono in Visual Studio
* Open `RDKitSimpleTest.sln` in Visual Studio
* From Project->Manage NuGet packages, install the RDKitDotNet package
* Build->Build Solution
* The `RDKitSimpleTest/RDKitSimpleTest/bin/<X64|X86>\<Release|Debug>` directory
should now contain:
```
RDKFuncs.dylib
RDKit2DotNet.dll
RDKitSimpleTest.exe
RDKitSimpleTest.exe.config
RDKitSimpleTest.pdb
```

* In a shell, run the following commands:
```
$ cd RDKitSimpleTest/RDKitSimpleTest
$ ln -s RDKFuncs.dylib RDKFuncs
$ DYLD_LIBRARY_PATH=$PWD mono RDKitSimpleTest.exe
```

# All platforms
* Running `RDKitSimpleTest.exe` should print a base64-encoded PNG string to the
console and generate:
```
coordgenSmiles.png
erythromycin_csharp.svg
rdkitSmiles.png
```
