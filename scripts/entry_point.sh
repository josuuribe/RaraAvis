#!/bin/sh
RA_SRVC=${RA_SRVC:-$(id -un)}

if [ "$RA_SRVC" = $(id -un) ]; then
  echo "Executing as self: $RA_SRVC"
  echo "You will need to be root or sudo"
  $@
else
  RA_SRVC=${RA_SRVC:-$(id -un)}
  uid=$(id -u $RA_SRVC)
  gid=$(id -g $RA_SRVC)
  RA_UUID=${RA_UUID:-$uid}
  RA_GUID=${RA_GUID:-$gid}
  RA_FLDR=${RA_FLDR:-$(pwd)}
  cat scripts/logo.txt
  echo "  Starting $RA_SRVC uid=$(id -u $RA_SRVC) gid=$(id -g $RA_SRVC)
  Setting user id:  $RA_UUID $(gosu root usermod -o -u $RA_UUID $RA_SRVC)
  -------------------------------------
  User:     $RA_SRVC $(id -u $RA_SRVC)
  Groups:   $(id -gn $RA_SRVC)
  Folder:   $RA_FLDR
  -------------------------------------
  Setting permissions on $RA_FLDR ($RA_UUID:$RA_GUID) $(gosu root chown -R $RA_UUID:$RA_GUID $RA_FLDR)
  Running $@
  "
  exec gosu $RA_SRVC $@
fi
