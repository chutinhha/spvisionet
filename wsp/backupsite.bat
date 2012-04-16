cd "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\BIN"
stsadm -o backup -url "http://kppwebdev" -filename "C:\backup\kppwebdev.bak" -overwrite
cd\ "C:\backup"