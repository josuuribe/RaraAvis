#! /bin/bash -

shopt -s nullglob
files=(./builder/*.sh)
shopt -u nullglob

for file in "${files[@]}"; do
  command . "$file"
done
