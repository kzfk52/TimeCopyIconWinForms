
REM If you want to code sign, please remove the EXIT.
EXIT /B 0

SET CERTSTOREFRIENDRYNAME="Open Source Developer, Kazuyuki Fukuda"
SET TIMESTAMPURL="http://time.certum.pl/"

signtool.exe sign /n %CERTSTOREFRIENDRYNAME% /a /fd sha256 /td sha256 /tr %TIMESTAMPURL% /v "%1"
echo Completed code signature for %1
echo ""

REM The above signs the DLL. Below, we sign the EXE.
set executable=%1%
set executable=%executable:.dll=.exe%
signtool.exe sign /n %CERTSTOREFRIENDRYNAME% /a /fd sha256 /td sha256 /tr %TIMESTAMPURL% /v "%executable%"
echo Completed code signature for %executable%
