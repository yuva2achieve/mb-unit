; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "MbUnit"
!define PRODUCT_VERSION "2.4.1"
!define PRODUCT_WEB_SITE "http://www.mbunit.com"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\XsdTidy.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "Setup.exe"
InstallDir "$PROGRAMFILES\MbUnit"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "build\XsdTidy.exe"
  File "build\TestFu.dll" 
  File "build\TestDriven.Framework.dll"
  File "build\Refly.dll"
  File "build\QuickGraph.dll"
  File "build\QuickGraph.Algorithms.Graphviz.dll"
  File "build\QuickGraph.Algorithms.dll"
  File "build\NGraphviz.Layout.dll"
  File "build\NGraphviz.Helpers.dll"
  File "build\NGraphviz.dll"
  File "build\NAnt.Core.dll"
  File "build\MbUnit.Tasks.dll"
  File "build\MbUnit.GUI.exe.config"
  File "build\MbUnit.GUI.exe"
  File "build\MbUnit.Framework.dll"
  File "build\MbUnit.Framework.2.0.dll"
  File "build\MbUnit.Cons.exe"
  File "build\MbUnit.Cons.exe.config"
  File "build\MbUnit.AddIn.dll"
  File "build\log4net.dll"
  File "build\MbUnit.MSBuild.Tasks.dll"

  WriteRegStr HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "" "10"
  WriteRegStr HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "AssemblyPath" "$PROGRAMFILES\MbUnit\MbUnit.AddIn.dll"
  WriteRegStr HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "TypeName" "MbUnit.AddIn.MbUnitTestRunner"
  WriteRegStr HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "TargetFrameworkAssemblyName" "MbUnit.Framework"
  WriteRegStr HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "Application" "$PROGRAMFILES\MbUnit\MbUnit.GUI.exe"
  
  WriteRegStr HKLM "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "" "10"
  WriteRegStr HKLM "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "AssemblyPath" "$PROGRAMFILES\MbUnit\MbUnit.AddIn.dll"
  WriteRegStr HKLM "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "TypeName" "MbUnit.AddIn.MbUnitTestRunner"
  WriteRegStr HKLM "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "TargetFrameworkAssemblyName" "MbUnit.Framework"
  WriteRegStr HKLM "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit" "Application" "$PROGRAMFILES\MbUnit\MbUnit.GUI.exe"
  
  WriteRegStr HKCU "SOFTWARE\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\MbUnit" "" "$PROGRAMFILES\MbUnit\"

  SetOutPath "$INSTDIR\VSSnippets\MbUnitCSharpSnippets"
  SetOverwrite try
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\autorunner.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\datafixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\model.snippet"  
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\rowtest.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\state.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\submodel.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\test.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\testexpectedexception.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\testfixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\testsuitefixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\typefixturewithproviderfactory.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\typefixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\usingmbunit.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\combinatorialtest.snippet"
  File "build\Snippets\VSSnippets\MbUnitCSharpSnippets\processtestfixture.snippet"

  SetOutPath "$INSTDIR\VSSnippets\MbUnitVBSnippets"
  SetOverwrite try

  File "build\Snippets\VSSnippets\MbUnitVBSnippets\autorunner.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\datafixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\model.snippet"  
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\rowtest.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\state.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\submodel.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\test.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\testexpectedexception.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\testfixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\testsuitefixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\typefixturewithproviderfactory.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\typefixture.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\usingmbunit.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\combinatorialtest.snippet"
  File "build\Snippets\VSSnippets\MbUnitVBSnippets\processtestfixture.snippet"
  
  SetOutPath "$INSTDIR\VSSnippets\MbUnitXMLSnippets"
  SetOverwrite try

  File "build\Snippets\VSSnippets\MbUnitXMLSnippets\msbuild.snippet"
  File "build\Snippets\VSSnippets\MbUnitXMLSnippets\nant.snippet"
  
  ;Register file association. 
  !define Index "Line${__LINE__}" 
  ReadRegStr $1 HKCR ".mbunit" "" 
  StrCmp $1 "" "${Index}-NoBackup" 
  StrCmp $1 "MbUnit" "${Index}-NoBackup" 
  WriteRegStr HKCR ".mbunit" "backup_val" $1 
  "${Index}-NoBackup:" 
  WriteRegStr HKCR ".mbunit" "" "MbUnit" 
  ReadRegStr $0 HKCR "MbUnit" "" 
  StrCmp $0 "" 0 "${Index}-Skip" 
  WriteRegStr HKCR "MbUnit" "" "MbUnit Project File" 
  WriteRegStr HKCR "MbUnit\shell" "" "open" 
  WriteRegStr HKCR "MbUnit\DefaultIcon" "" "$INSTDIR\MbUnit.GUI.exe,0" 
  "${Index}-Skip:" 
  WriteRegStr HKCR "MbUnit\shell\open\command" "" '$INSTDIR\MbUnit.GUI.exe "%1"' 

  System::Call 'Shell32::SHChangeNotify(i 0x8000000, i 0, i 0, i 0)' 
  !undef Index 
  
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\XsdTidy.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\XsdTidy.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "MbUnit was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove MbUnit and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\autorunner.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\datafixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\model.snippet"  
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\rowtest.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\state.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\submodel.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\test.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\testexpectedexception.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\testfixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\testsuitefixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\typefixturewithproviderfactory.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\typefixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\usingmbunit.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\combinatorialtest.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\processtestfixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\autorunner.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\datafixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\model.snippet"  
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\rowtest.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\state.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\submodel.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\test.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\testexpectedexception.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\testfixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\testsuitefixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\typefixturewithproviderfactory.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\typefixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\usingmbunit.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\combinatorialtest.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitVBSnippets\processtestfixture.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitXMLSnippets\msbuild.snippet"
  Delete "$INSTDIR\VSSnippets\MbUnitXMLSnippets\nant.snippet"
  Delete "$INSTDIR\log4net.dll"
  Delete "$INSTDIR\MbUnit.AddIn.dll"
  Delete "$INSTDIR\MbUnit.Demo.1.1.dll"
  Delete "$INSTDIR\MbUnit.Framework.2.0.dll" 
  Delete "$INSTDIR\MbUnit.Framework.dll" 
  Delete "$INSTDIR\MbUnit.GUI.exe"
  Delete "$INSTDIR\MbUnit.GUI.exe.config"
  Delete "$INSTDIR\MbUnit.MSBuild.Tasks.dll"
  Delete "$INSTDIR\MbUnit.Tasks.dll"
  Delete "$INSTDIR\MbUnit.Tests.1.1.dll"
  Delete "$INSTDIR\NAnt.Core.dll"
  Delete "$INSTDIR\NGraphviz.dll"
  Delete "$INSTDIR\NGraphviz.Helpers.dll"
  Delete "$INSTDIR\NGraphviz.Layout.dll"
  Delete "$INSTDIR\QuickGraph.Algorithms.dll"
  Delete "$INSTDIR\QuickGraph.Algorithms.Graphviz.dll"
  Delete "$INSTDIR\QuickGraph.dll"
  Delete "$INSTDIR\Refly.dll"
  Delete "$INSTDIR\TestDriven.Framework.dll"
  Delete "$INSTDIR\TestFu.dll"  
  Delete "$INSTDIR\XsdTidy.exe"
  Delete "$INSTDIR\MbUnit.Cons.exe"
  Delete "$INSTDIR\MbUnit.Cons.exe.config"

  RMDir "$SMPROGRAMS\\"
  RMDir "$INSTDIR\VSSnippets\MbUnitXMLSnippets\"
  RMDir "$INSTDIR\VSSnippets\MbUnitVBSnippets\"
  RMDir "$INSTDIR\VSSnippets\MbUnitCSharpSnippets\"
  RMDir "$INSTDIR\VSSnippets\"
  RMDir "$INSTDIR"

  DeleteRegKey HKCU "SOFTWARE\MutantDesign\TestDriven.NET\TestRunners\MbUnit"
  DeleteRegKey HKCU "SOFTWARE\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\MbUnit"
  
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  
  ;Unregister file association 
  !define Index "Line${__LINE__}" 
  ReadRegStr $1 HKCR ".mbunit" "" 
  StrCmp $1 "OptionsFile" 0 "${Index}-NoOwn" ; only do this if we own it 
  ReadRegStr $1 HKCR ".mbunit" "backup_val" 
  StrCmp $1 "" 0 "${Index}-Restore" ; if backup="" then delete the whole key 
  DeleteRegKey HKCR ".mbunit" 
  Goto "${Index}-NoOwn" 
  "${Index}-Restore:" 
  WriteRegStr HKCR ".mbunit" "" $1 
  DeleteRegValue HKCR ".mbunit" "backup_val" 

  DeleteRegKey HKCR "MbUnit" ;Delete key with association settings 

  System::Call 'Shell32::SHChangeNotify(i 0x8000000, i 0, i 0, i 0)' 
  "${Index}-NoOwn:" 
  !undef Index 
  
  
  SetAutoClose true
SectionEnd
