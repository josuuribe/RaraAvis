# ehough/docker-kodi - Dockerized Kodi with audio and video.
#
# https://github.com/ehough/docker-kodi
# https://hub.docker.com/r/erichough/kodi/
#
# Copyright 2018-2020 - Eric Hough (eric@tubepress.com)
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.

# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.

# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <https://www.gnu.org/licenses/>.

FROM balenalib/raspberrypi3-debian:bullseye

ARG DEBIAN_FRONTEND=noninteractive
# 1 for HDMI, 0 for headphones
ARG     AUDIO=1

RUN	apt-get update				&& \
	apt-get -y purge openssl		&& \
	apt-get -y --purge autoremove		&& \
	apt-get dist-upgrade			&& \
	apt-get install	-y			\			
	uuid-dev		\
	upower			\
	alsa-base		\
	alsa-utils		\
	alsa-tools		\
	dbus-x11		\
	libraspberrypi0		\
	xterm			\
	xinput			\
	xinput-calibrator	\
	evemu-tools		\	
	libnspr4		\
	libwidevinecdm0		\
	libc6			\
	avahi-daemon		\
	libnss-mdns		\
	nano			\
	lirc			\
	lirc-compat-remotes	\
	bluez			\
	dumb-init		\
# Required for AirPlay Mirroring
	cmake					\
        libavahi-compat-libdnssd-dev		\
        libplist-dev				\
        libgstreamer1.0-dev			\
        libx264-dev				\
        libjpeg-dev				\
        libgstreamer-plugins-base1.0-dev	\
        libgstreamer-plugins-bad1.0-dev		\
        gstreamer1.0-plugins-ugly		\
        gstreamer1.0-tools			\
        gstreamer1.0-gl				\
        gstreamer1.0-gtk3			\
        git					\
        git-svn					\
        libssl-dev				\
# Python required for Netflix, Amazon...
	python3-pip		\
	build-essential		&& \
# Install some Python packages
	pip install setuptools pycryptodome pycryptodomex wheel pycrypto				&& \
	apt-get -y --purge autoremove									&& \
	rm -rf /var/lib/apt/lists/*

# besides kodi, we will install a few extra packages:
#  - ca-certificates              allows Kodi to properly establish HTTPS connections
#  - kodi-eventclients-kodi-send  allows us to shut down Kodi gracefully upon container termination
#  - kodi-game-libretro           allows Kodi to utilize Libretro cores as game add-ons
#  - kodi-game-libretro-*         Libretro cores
#  - kodi-inputstream-*           input stream add-ons
#  - kodi-peripheral-*            enables the use of gamepads, joysticks, game controllers, etc.
#  - kodi-pvr-*                   PVR add-ons
#  - kodi-screensaver-*           additional screensavers
#  - lirc,lirc-compat-remotes     enables the use of IR Remotes
#  - locales                      additional spoken language support (via x11docker --lang option)
#  - pulseaudio                   in case the user prefers PulseAudio instead of ALSA
#  - tzdata                       necessary for timezone selection
RUN packages="                                               \
    fbset                                                    \
    ca-certificates                                          \
    kodi                                                     \
    kodi-eventclients-kodi-send                              \
    kodi-inputstream-adaptive                                \
    kodi-inputstream-rtmp                                    \
    kodi-peripheral-joystick                                 \
    kodi-pvr-argustv                                         \
    kodi-pvr-dvblink                                         \
    kodi-pvr-dvbviewer                                       \
    kodi-pvr-filmon                                          \
    kodi-pvr-hdhomerun                                       \
    kodi-pvr-hts                                             \
    kodi-pvr-iptvsimple                                      \
    kodi-pvr-mediaportal-tvserver                            \
    kodi-pvr-mythtv                                          \
    kodi-pvr-nextpvr                                         \
    kodi-pvr-njoy                                            \
    kodi-pvr-pctv                                            \
    kodi-pvr-sledovanitv-cz                                  \
    kodi-pvr-stalker                                         \
    kodi-pvr-teleboy                                         \
    kodi-pvr-vbox                                            \
    kodi-pvr-vdr-vnsi                                        \
#    kodi-pvr-vuplus                                          \ # Not yet available
    kodi-pvr-wmc                                             \
    kodi-pvr-zattoo                                          \
    kodi-screensaver-biogenesis                              \
    kodi-screensaver-matrixtrails                            \
    kodi-screensaver-pyro                                    \
    kodi-screensaver-stars                                   \
    lirc                                                     \
    lirc-compat-remotes                                      \
    locales                                                  \
    libnss3                                                  \
    tzdata"                                               && \
                                                             \
    apt-get update                                        && \
    apt-get install -y $packages                          


# Audio settings
RUN     echo            \
"pcm.!default {         \n\
  type asym             \n\
  playback.pcm {        \n\
  type plug             \n\
  slave.pcm "output"    \n\
}                       \n\
capture.pcm {           \n\
  type plug             \n\
  slave.pcm "input"     \n\
  }                     \n\
}                       \n\
pcm.output {            \n\
  type hw               \n\
  card $AUDIO           \n\
}                       \n\
ctl.!default {          \n\
  type hw               \n\
  card $AUDIO           \n\
}" >> /etc/asound.conf

# Adding user
ENV	KODI_ID=1000
RUN     adduser \
	--uid $KODI_ID \
	--disabled-password \
	--gecos '' \
	--ingroup sudo \
	kodi 
RUN     echo '%sudo ALL=(ALL) NOPASSWD:ALL' >> /etc/sudoers
RUN	usermod -a -G audio,video,input,dialout,plugdev,netdev,users,cdrom,tty kodi

# Install RpiPlay
WORKDIR /opt/vc
RUN     git svn clone https://github.com/raspberrypi/firmware/trunk/opt/vc/include
RUN     git svn clone https://github.com/raspberrypi/firmware/trunk/opt/vc/src
RUN	git svn clone https://github.com/raspberrypi/firmware/trunk/opt/vc/lib

WORKDIR /repos
COPY    rpiplay.tar.gz .
RUN     tar -zxvf rpiplay.tar.gz
RUN	ls -la
WORKDIR /repos/rpiplay/build
RUN	ls -la
RUN	cmake ..
RUN	make -j 4
WORKDIR /
RUN	rm -rf /repos
RUN	rm -rf /rpiplay.tar.gz

# Plugins

WORKDIR	/plugins
ADD	--chown=kodi:sudo https://github.com/castagnait/repository.castagnait/raw/kodi/repository.castagnait-2.0.0.zip .
ADD	--chown=kodi:sudo https://k.slyguy.xyz/repository.slyguy.zip .
ADD	--chown=kodi:sudo https://github.com/Sandmann79/xbmc/releases/download/Repository/repository.sandmann79.plugins-1.0.4.zip .

# Configuration
EXPOSE	8080 9777/udp

VOLUME	/home/kodi
USER	kodi

COPY entrypoint.sh /usr/local/bin
CMD ["/usr/local/bin/entrypoint.sh"]
