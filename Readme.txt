******************************************************************************************************
1.Place it inside the folder having mp4 files
2.Run Convert2Mp3.exe (in admin Mode is possible)
3.All the mp4 files will get converted to mp3.If the file names have some character like ' or ` it will 
show error.
******************************************************************************************************

*************OtherOptions*****************************************************************************************


For converting only .mp4 files:

mkdir outputs
for f in *.mp4; do ffmpeg -i "$f" -c:a libmp3lame "outputs/${f%.mp4}.mp3"; done
For converting .m4a, .mov, and .flac:

mkdir outputs
for f in *.{m4a,mov,flac}; do ffmpeg -i "$f" -c:a libmp3lame "outputs/${f%.*}.mp3"; done
For converting anything use the "*" wildcard:

mkdir outputs
for f in *; do ffmpeg -i "$f" -c:a libmp3lame "outputs/${f%.*}.mp3"; done