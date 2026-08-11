id=$(docker run --name build-rpiplay -dit joursain/rpi-build-rpiplay:buster)
echo $id
docker cp $id:/repos/drop/rpiplay.tar.gz .
docker container stop build-rpiplay
docker container rm $id
docker run --name build-rpiplay joursain/rpi-build-rpiplay:buster
