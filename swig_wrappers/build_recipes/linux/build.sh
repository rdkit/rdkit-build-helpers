#!/usr/bin/env bash

usage()
{
cat 1>&2 << EOF
Usage: cd into x86_64 directory, then run
../build.sh [--clean]
Pass --clean to do a clean build starting from scratch.

EOF
exit
}

ARCH=`basename $PWD`
NO_CACHE=""

[ "$ARCH" != "x86_64" ] && usage
( [ "$1" = "-h" ] || [ "$1" = "--help" ] ) && usage

[ "$1" = "--clean" ] && NO_CACHE="--no-cache"

docker build $NO_CACHE -t rdkit-knime-linux-${ARCH} -f ../Dockerfile_linux_${ARCH} --network=host --build-arg "ARCH=${ARCH}" ..
docker create --name=rdkit-knime-linux-${ARCH}-container rdkit-knime-linux-${ARCH}:latest --entrypoint /
docker cp rdkit-knime-linux-${ARCH}-container:/${ARCH}/. .
docker rm rdkit-knime-linux-${ARCH}-container
