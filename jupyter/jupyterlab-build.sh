rm jupyterlab.out 2>/dev/null
nohup docker build -t joursain/rpi-jupyterlab:buster -f Dockerfile.jupyterlab . > jupyterlab.out &
sleep 10
tail -fn 20 jupyterlab.out

