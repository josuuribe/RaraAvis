docker container run \
--init \
--publish 6680:6680 \
--device /dev/snd \
--volume /mnt/media/mopidy/config:/mnt/mopidy/config \
--volume /mnt/samba/server/black/music/:/mnt/mopidy/local \
--env RA_UUID=1000 \
--env RA_GUID=1000 \
--env RA_SRVC=mopidy \
--env RA_FLDR=/mnt/mopidy \
--detach \
--name mopidy \
joursain/raspberry-mopidy


