#!/usr/bin/env zsh

usage()
{
cat 1>&2 << EOF
Usage: cd into arm64 or x86_64 directory, then run
../build.sh [--clean]
Pass --clean to do a clean build starting from scratch.

EOF
exit
}

no_python3()
{
cat 1>&2 << EOF
Aborting - a python3 executable is required.

EOF
exit 1
}

ARCH=`basename $PWD`

[ "$ARCH" != "arm64" ] && [ "$ARCH" != "x86_64" ] && usage
( [ "$1" = "-h" ] || [ "$1" = "--help" ] ) && usage

[ "$1" = "--clean" ] && ( ls -l && ls -ld ../noarch ) | grep ^d | awk "{print \"rm -rf \"\$NF}" 1>&2 | sh
! which python3 > /dev/null && no_python3

[ ! -e ../noarch/rdkit_knime/bin/activate ] && python3 -m venv ../noarch/rdkit_knime
. ../noarch/rdkit_knime/bin/activate
! which ansible-playbook > /dev/null && pip install ansible
ansible-playbook --connection=local --limit 127.0.0.1 --extra-vars "ARCH=$ARCH" ../Ansible_playbook_macOS.yml
