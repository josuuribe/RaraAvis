#!/bin/sh
RA_SRVC=${RA_SRVC:-$(id -un)}

if [ "$RA_SRVC" = $(id -un) ]; then
  echo "Executing as self: $RA_SRVC"
  $@
else
  uid=$(id -u $RA_SRVC)
  gid=$(id -g $RA_SRVC)
  RA_UUID=${RA_UUID:-$uid}
  RA_GUID=${RA_GUID:-$gid}
  RA_FLDR=${RA_FLDR:-$(pwd)}
  cat /mnt/transmission/scripts/logo.txt
  #echo " $uid $gid $RA_UUID $RA_GUID $RA_FLDR"
  echo "  Starting $RA_SRVC uid=$(id -u $RA_SRVC) gid=$(id -g $RA_SRVC)
  Setting group id: $RA_GUID $(sudo groupmod -o -g $RA_GUID $RA_SRVC)
  Setting user id:  $RA_UUID $(sudo usermod -o -u $RA_UUID $RA_SRVC)
  -------------------------------------
  User:     $RA_SRVC $(id -u $RA_SRVC)
  Group:    $RA_SRVC $(id -g $RA_SRVC)
  Folder:   $RA_FLDR
  -------------------------------------
  Setting permissions on $RA_FLDR $(sudo chown -R $RA_UUID:$RA_GUID $RA_FLDR)
  Running $@
  "
  sudo -u "$RA_SRVC" $@
fi
