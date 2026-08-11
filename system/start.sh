docker run \
--device=/dev/tty0 \
--device=/dev/tty2 \
--device=/dev/input \
--device=/dev/rfkill \
-v /var/run/dbus:/var/run/dbus \
-v /etc/localtime:/etc/localtime \
-v /etc/timezone:/etc/timezone \
-v /mnt/dnsmasq:/etc/dnsmasq \
-v /lib/modules:/lib/modules \
-v /etc/wpa_supplicant:/etc/wpa_supplicant \
--cap-add=NET_ADMIN \
--net=host \
--name raspap \
joursain/rpi-system-raspap:bullseye
