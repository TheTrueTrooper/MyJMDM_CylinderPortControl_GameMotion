Rem Make one of these for every game
Rem in the second qotes put the location of the thing that you want to start
Rem This is the place where you would start the game put the games .bat or starter here not that you could put their .bat info here.
Rem start "" "c:\program files\Microsoft Virtual PC\Virtual PC.exe"
Rem this is the place where you start the machines starter 
Rem in the second qotes put the location of the thing that you want to start
Rem -Com: is for the Comport number -File is for the .JMMov file location -NumberOfCylinder is for the number of cylies the machine has 3 is the usal and 6 is the max  -StartWait is for adding extra time before the actual game starts for syncing movements -EndWait is for adding extra time before the actual game starts for syncing movements
start "" "C:\Users\Angelo's Tower PC\source\repos\MyJMDM_CylinderPortControl\GameMotion\bin\Debug\GameMotion.exe" -Com:6 -File:"C:\Users\Angelo's Tower PC\Desktop\Game Move Data\CXV.Files\3 dof suitable all 3dof machine\03-Birth of baby_3DOF.JMMov" -StartWait:4000 -EndWait:4000 -NumberOfCylinder:3