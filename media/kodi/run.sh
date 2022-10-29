docker run \
--device=/dev/tty0 \
--device=/dev/tty2 \
--device=/dev/fb0 \
--device=/dev/input \
--device=/dev/snd \
--device=/dev/vchiq \
-v /var/run/dbus:/var/run/dbus \
-v /etc/localtime:/etc/localtime \
-v /etc/timezone:/etc/timezone \
-v /home/pi/kodi-rpi/config:/config/kodi \
-v /home/pi/kodi-rpi/data:/data \
-v /usr/bin/tvservice:/usr/bin/tvservice \
-p 8080:8080 \
-p 9777:9777/udp \
joursain/kodi2


