#!/usr/bin/env bash

usage()
{
cat 1>&2 << EOF
Usage: cd into x86_64 or i686 directory, then run
../build.sh [--clean]
Pass --clean to do a clean build starting from scratch.

EOF
exit
}

ARCH=`basename $PWD`
NO_CACHE=""

[ "$ARCH" != "x86_64" ] && [ "$ARCH" != "i686" ] && usage
( [ "$1" = "-h" ] || [ "$1" = "--help" ] ) && usage

[ "$1" = "--clean" ] && NO_CACHE="--no-cache"

docker build $NO_CACHE -t rdkit-knime-windows-${ARCH} -f ../Dockerfile_windows --network=host --build-arg "ARCH=${ARCH}" ..
docker create --name=rdkit-knime-windows-${ARCH}-container rdkit-knime-windows-${ARCH}:latest --entrypoint /
docker cp rdkit-knime-windows-${ARCH}-container:/${ARCH}/. .
docker rm rdkit-knime-windows-${ARCH}-container
