@echo off
cd src
javac -d ..\out com\matteofuso\adt\*.java
javac -d ..\out com\matteofuso\arrays\*.java
javac -d ..\out Main.java

cd ..\out
java Main
pause