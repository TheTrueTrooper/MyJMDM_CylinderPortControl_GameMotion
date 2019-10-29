Args for operation
-Com:6 << sets the com. simply set the number to the desired com port number
-File:"C:\Users\..\Desktop\Game Move Data\CXV.Files\3 dof suitable all 3dof machine\03-Birth of baby_3DOF.JMMov" <sets the motion files location
-StartWait:4000 << sets the number of miliseconds to wait until motion
-EndWait:4000 << sets the number of miliseconds to wait until ending self
-NumberOfCylinder:3 << sets the max number of cylinders to allow to fire
-ProccesName:Discord << Set the name of the program to wait on or send input to
-AddInput:"Wait(3000) keydown(space) Wait(300) keyup(space)" << Set the commands to give to the other program as input.

Supported Commands
wait(miliseconds) << Waits a desired number of miliseconds before the next command 
leftmouseclickdown(x,y) << Sends a left mouse click (down) message to the other window as input at the x and y
leftmouseclickup(x,y) << Sends a left mouse click (up) message to the other window as input at the x and y
keydown(sting) << Sends a left keypress (down) message to the other window as input
keyup(sting) << Sends a left keypress (up) message to the other window as input

ReconizedKeys
0-9 keys as thier char value
A-Z keys as thier char value
,./;'[]-= keys as thier char value
shift for input == "shift"
tab for input == "tab"
control for input == "control"
enter for input == "enter"
space for input == "space"
alt for input == "alt"