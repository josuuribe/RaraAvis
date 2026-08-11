rm raspap.out 2>/dev/null
nohup docker build -t joursain/rpi-system-raspap:bullseye -f Dockerfile.raspap . > raspap.out &
sleep 1
tail -fn 20 raspap.out

