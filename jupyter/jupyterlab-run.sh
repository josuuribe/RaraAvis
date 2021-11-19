docker container run \
 --init \
--name jupyterlab \
--publish 8888:8888 \
--detach \
--volume /home/pi/jupyterlab:/home/jupyter/notebooks \
joursain/rpi-jupyterlab:buster
