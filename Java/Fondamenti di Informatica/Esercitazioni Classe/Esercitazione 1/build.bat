@echo off
REM =====================================================
REM Build script: clean, compile, generate Javadoc
REM =====================================================

REM Imposta le variabili
SET BIN_DIR=Cifrario\bin
SET JAVADOC_DIR=Javadoc
SET SRC_DIR=Cifrario\src
SET JDK_PATH=C:\Program Files\Java\jdk-25\bin

REM =====================================================
REM Pulizia cartelle bin e Javadoc
REM =====================================================
echo Pulizia cartelle bin e Javadoc...
if exist "%BIN_DIR%" rmdir /s /q "%BIN_DIR%"
if exist "%JAVADOC_DIR%" rmdir /s /q "%JAVADOC_DIR%"

REM Ricrea le cartelle vuote
mkdir "%BIN_DIR%"
mkdir "%JAVADOC_DIR%"

REM =====================================================
echo Compilazione Java source files...
REM =====================================================

"%JDK_PATH%\javac.exe" -d "%BIN_DIR%" "%SRC_DIR%\com\matteofuso\cifrario\Operazioni.java"
"%JDK_PATH%\javac.exe" -cp "%BIN_DIR%" Main.java

REM =====================================================
echo Generazione Javadoc...
REM =====================================================

"%JDK_PATH%\javadoc.exe" -d "%JAVADOC_DIR%" "%SRC_DIR%\com\matteofuso\cifrario\Operazioni.java"

echo.
echo Build completato con successo!
pause
