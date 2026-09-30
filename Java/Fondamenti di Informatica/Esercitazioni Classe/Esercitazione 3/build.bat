@echo off
cd src
javac -d ../bin com/matteofuso/music/*.java
javac -d ../bin com/matteofuso/app/Main.java
javadoc -d ../Javadoc com/matteofuso/app/Main.java
pause