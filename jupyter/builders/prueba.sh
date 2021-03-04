#!/bin/bash
git clone --recursive https://github.com/pytorch/pytorch

if [ "$?" = "0" ]; then
	echo "Repository cloned"
	cd pytorch
else
	cd pytorch
	git pull
	echo "Repository updated"
fi

cd pytorch
git checkout master -b build
git submodule update --init --recursive

export NO_CUDA=1
export NO_DISTRIBUTED=1

#python3 setup.py build
#date && python3 setup.py build && date &> message-build &
#python3 setup.py bdist_wheel
#cd dist
#ls -la
