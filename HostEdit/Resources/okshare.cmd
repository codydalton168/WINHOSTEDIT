@echo off
echo Windows Registry Editor Version 5.00>>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg
sc config LanmanWorkstation start= auto>nul 2>nul
sc config LanmanServer start= auto>nul 2>nul
sc config Winmgmt start= auto>nul 2>nul
sc config RpcSs start= auto>nul 2>nul
sc config Netman start= auto>nul 2>nul
sc config RasMan start= demand>nul 2>nul
sc config SSDPSRV start= auto>nul 2>nul
sc config BFE start= auto>nul 2>nul
sc config ALG start= demand>nul 2>nul
sc config SharedAccess start= auto>nul 2>nul
net start SharedAccess /y>nul 2>nul
sc config Browser start= auto>nul 2>nul
net start Browser /y>nul 2>nul
sc config Dnscache start= auto>nul 2>nul
net start Dnscache /y>nul 2>nul
sc config Dhcp start= auto>nul 2>nul
net start Dhcp /y>nul 2>nul
sc config lmhosts start= auto>nul 2>nul
net start lmhosts /y>nul 2>nul
sc config Spooler start= auto>nul 2>nul
net start Spooler /y>nul 2>nul
sc config upnphost start= demand>nul 2>nul
net start upnphost /y>nul 2>nul
sc config Netlogon start= demand>nul 2>nul
net start Netlogon /y>nul 2>nul



sc config DcomLaunch start= auto>nul 2>nul
sc config RpcEptMapper start= auto>nul 2>nul
sc config SamSs start= auto>nul 2>nul
sc config nsi start= auto>nul 2>nul
sc config SstpSvc start= demand>nul 2>nul
sc config MpsSvc start= auto>nul 2>nul
net start MpsSvc /y>nul 2>nul
sc config NlaSvc start= auto>nul 2>nul
sc config netprofm start= auto>nul 2>nul
sc config fdPHost start= auto>nul 2>nul
sc config FDResPub start= auto>nul 2>nul
sc config HomeGroupListener start= auto>nul 2>nul
sc config WMPNetworkSvc start= auto>nul 2>nul
net start WMPNetworkSvc /y>nul 2>nul
sc config HomeGroupProvider start= auto>nul 2>nul
net start HomeGroupProvider /y>nul 2>nul
netsh advfirewall set allprofiles state off>nul 2>nul
echo [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\MSV1_0]>>%temp%\okshare.reg
echo "NtlmMinClientSec"=dword:00000000>>%temp%\okshare.reg
echo "NtlmMinServerSec"=dword:00000000>>%temp%\okshare.reg
echo "LmCompatibilityLevel"=dword:00000001>>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg


net user guest /active:yes>nul 2>nul
echo [Unicode]>>%temp%\admin_sec.inf
echo Unicode=yes>>%temp%\admin_sec.inf
echo [Version]>>%temp%\admin_sec.inf
echo signature="$CHICAGO$">>%temp%\admin_sec.inf
echo Revision=1>>%temp%\admin_sec.inf
echo [Privilege Rights]>>%temp%\admin_sec.inf
echo sedenynetworklogonright = >>%temp%\admin_sec.inf
echo senetworklogonright = Everyone,Administrators,Users,Power Users,Backup Operators,guest>>%temp%\admin_sec.inf
secedit /configure /db %temp%\admin_sec.sdb /cfg %temp%\admin_sec.inf /log %temp%\admin_sec.log /quiet
del /q %temp%\admin_sec.*>nul 2>nul
echo [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa]>>%temp%\okshare.reg
echo "forceguest"=dword:00000001>>%temp%\okshare.reg
echo "limitblankpassworduse"=dword:00000000>>%temp%\okshare.reg
echo "restrictanonymous"=dword:00000000>>%temp%\okshare.reg
echo "restrictanonymoussam"=dword:00000000>>%temp%\okshare.reg
echo "everyoneincludesanonymous"=dword:00000001>>%temp%\okshare.reg
echo "NoLmHash"=dword:00000000>>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg
echo [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters]>>%temp%\okshare.reg
echo "AutoShareServer"=dword:00000000>>%temp%\okshare.reg
echo "AutoShareWks"=dword:00000000>>%temp%\okshare.reg
echo "restrictnullsessaccess"=dword:00000000>>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg


net use * /del /y>nul 2>nul
net config server /hidden:no>nul 2>nul
net share ipc$>nul 2>nul
echo [-HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\RemoteComputer\NameSpace\{D6277990-4C6A-11CF-8D87-00AA0060F5BF}]>>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg
echo [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Browser\Parameters]>>%temp%\okshare.reg
echo "MaintainServerList"="Auto">>%temp%\okshare.reg
echo "IsDomainMaster"="FALSE">>%temp%\okshare.reg
echo.&echo.>>%temp%\okshare.reg
regedit /s %temp%\okshare.reg
del /f /q %temp%\okshare.reg


