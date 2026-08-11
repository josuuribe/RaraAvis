#!/bin/bash

log () {
  echo "---> $1"
}

start_raspap () {
  log "starting RaspAp."
  sudo service dnsmasq start
  sudo service hostapd start
#  sudo service lighttpd start
  lighttpd -D -f /etc/lighttpd/lighttpd.conf
#  sudo ps -aux
#  ls  -la /var/log/lighttpd
#  cat /var/log/lighttpd/error.log
#  cat /var/log/messages
#  dmesg
  log "end RaspAp."
}

start_raspap
