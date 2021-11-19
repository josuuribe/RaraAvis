#!/bin/bash

if [ -z $1 ]; then
	echo "No paramater!!!"
	exit 1
fi

rm $1.out 2>/dev/null
nohup docker build -t joursain/rpi-$1:buster -f Dockerfile.$1 . > $1.out &
sleep 10
tail -fn 20 $1.out

