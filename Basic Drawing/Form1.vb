

' Pipe B1 visibility only works when running - rethink how the timer works - have it enabled and have a running flag to move things or not.
' extra comment to trigger git

' Adding Gear M1 , shaft M1, Gear M2

Public Class Form1

    ' Declarations

    ' Temporary variables

    ' these are used as the holders of the sin and cos values before 
    ' diameter/length and ofsets are aplied
    Private Property Temp_X As Object
    Private Property Temp_Y As Object



    ' Variable for the logic of the Program - not the maths of the machine
    Private Property Running As Object
    Private Property Run_Once As Object



    ' Mechanism Objects and supporting variable

    ' Gear B1
    ' This is the main input gear
    Private Property Gear_B1_Centre_X As Object
    Private Property Gear_B1_Centre_Y As Object
    Private Property Gear_B1_Angle As Object
    Private Property Gear_B1_Diameter As Object
    ' Gear B1 has a Gear and LineA and LineB
    ' Centre at 180,340  
    ' Diamater 258 ==> (location 51, 211)
    ' teeth 223 (not relevant as only input driven)

    ' Pipe_B1
    ' This is the pipe from B1 to B2 - Shaft B3 goes inside it.
    ' Also goes through front plate to connect to sun/calendar? arm
    ' Use Gear_B1_Centre_X
    ' Use Gear_B1_Centre_Y
    Private Property Pipe_B1_Diameter As Object
    ' diameter 12





    'Arm B1
    ' This is the Sun arm
    ' It is directly linked to Gear B1 (Shaft B1) 
    ' with no rotational ofset.
    ' use Gear_B1_Centre_X
    ' use Gear_B1_Centre_Y
    ' use Gear_B1_Angle
    Private Property Arm_B1_Length As Object
    Private Property Arm_B1_Tip_X As Object
    Private Property Arm_B1_Tip_Y As Object
    ' Arm B1 has itself and Sun

    ' Gear B3
    ' This is the driven Moon gear
    ' Driven by gear E1
    ' Use Gear_B1_Centre_X
    ' Use Gear_B1_Centre_Y
    Private Property Gear_B3_Angle As Object
    Private Property Gear_B3_Diameter As Object

    ' Arm B3
    ' This is the Moon Arm
    ' It is directly linked to Gear B3 (Shaft B3 - inside pipe/shaft B1)
    ' Initial position not clear so set to 0
    ' Use Gear_B1_Centre_X
    ' Use Gear_B1_Centre_Y
    ' Use Gear_B3_Angle
    Private Property Arm_B3_Length As Object
    Private Property Arm_B3_Tip_X As Object
    Private Property Arm_B3_Tip_Y As Object
    ' Arm B3 has itself and Moon

    ' Shaft B3
    ' Goes up from B3 (inside Pipe B1)
    ' Use Gear_B1_Centre_X
    ' Use Gear_B1_Centre_Y
    Private Property Shaft_B3_Diameter As Object
    ' diameter 4


    ' Gear B2
    ' This is the secondary input gear
    ' it is directly linked to Gear B1 on Shaft B1
    ' with no rotational ofset.
    ' use Gear_B2_Centre_X 
    ' use Gear_B2_Centre_Y 
    ' use Gear_B2_Angle
    Private Property Gear_B2_Diameter As Object
    ' Gear B2 has a Gear and LineA and LineB
    ' Gear B2 has 64 teeth
    ' Gear B2 drives Gear C1 (38 teeth) in the Lunar chain
    ' Gear B2 drives Gear I1 (38 teeth) in the Metonic chain

    ' Gear C1
    ' This is driven by Gear B2
    ' Initial position (trivial) set to 0
    Private Property Gear_C1_Centre_X As Object
    Private Property Gear_C1_Centre_Y As Object
    Private Property Gear_C1_Angle As Object
    Private Property Gear_C1_Diameter As Object
    ' Gear C1 has a Gear and LineA and LineB
    ' Gear C1 has 38 teeth
    ' Gear C1 drives Shaft C1 to Gear C2 (48 teeth) in the Lunar chain


    ' Shaft C1
    ' Goes from C1 to C2 Mounted on Main Plate
    ' Use Gear_C1_Centre_X
    ' Use Gear_C1_Centre_Y
    Private Property Shaft_C1_Diameter As Object
    ' diameter 4


    ' Gear L1
    ' This is driven by Gear B2
    ' Initial position (trivial) set to 0
    Private Property Gear_L1_Centre_X As Object
    Private Property Gear_L1_Centre_Y As Object
    Private Property Gear_L1_Angle As Object ' could use Gear_C1_Angle - but better not to for clarity
    Private Property Gear_L1_Diameter As Object
    ' Gear L1 has a Gear and LineA and LineB
    ' Gear L1 has 38 teeth
    ' Gear L1 drives Shaft L1 to Gear L2 (53 teeth) in the Metonic (and Saros) chain


    ' Shaft L1
    ' Goes from L1 to L2 Mounted on Main Plate
    ' Use Gear_L1_Centre_X
    ' Use Gear_L1_Centre_Y
    Private Property Shaft_L1_Diameter As Object
    ' diameter 4

    ' Gear C2
    ' This is driven by Shaft C1
    ' Initial position (trivial) set to 0
    ' Use Gear_C1_Centre_X 
    ' Use Gear_C1_Centre_Y 
    ' Use Gear_C1_Angle 
    Private Property Gear_C2_Diameter As Object
    ' Gear C2 has a Gear and LineA and LineB
    ' Gear C2 has 48 teeth
    ' Gear C2 drives Gear D1 (24 teeth) in the Lunar chain




    ' Gear L2
    ' This is driven by Shaft L1
    ' Initial position (trivial) set to 0
    ' Use Gear_L1_Centre_X 
    ' Use Gear_L1_Centre_Y 
    ' Use Gear_L1_Angle 
    Private Property Gear_L2_Diameter As Object
    ' Gear L2 has a Gear and LineA and LineB
    ' Gear L2 has 53 teeth
    ' Gear L2 drives Gear M1 (96 teeth) in the Metonic (and Soros) chain







    ' Gear D1
    ' This is driven by Gear C2
    ' Initial position (trivial) set to 0
    Private Property Gear_D1_Centre_X As Object
    Private Property Gear_D1_Centre_Y As Object
    Private Property Gear_D1_Angle As Object
    Private Property Gear_D1_Diameter As Object
    ' Gear D1 has a Gear and LineA and LineB
    ' Gear D1 has 24 teeth
    ' Gear D1 drives Shaft D1 (through main plate) to Gear D2 (127 teeth) in the Lunar chain

    ' Shaft D1
    ' Goes from D1 to D2 runs through Main Plate (do we need to show a hole/bearing in it?)
    ' Use Gear_D1_Centre_X
    ' Use Gear_D1_Centre_Y
    Private Property Shaft_D1_Diameter As Object
    ' diameter 4


    ' Gear D2
    ' This is driven by Shaft D1
    ' Initial position (trivial) set to 0
    ' Use Gear_D1_Centre_X 
    ' Use Gear_D1_Centre_Y 
    ' Use Gear_D1_Angle 
    Private Property Gear_D2_Diameter As Object
    ' Gear D2 has a Gear and LineA and LineB
    ' Gear D2 has 127 teeth
    ' Gear D2 drives Gear E2 (32) and pipe E2 to Gear E5(50) in the Lunar chain








    ' Gear M1
    ' This is driven by Gear L2
    ' Initial position (trivial) set to 0
    Private Property Gear_M1_Centre_X As Object
    Private Property Gear_M1_Centre_Y As Object
    Private Property Gear_M1_Angle As Object
    Private Property Gear_M1_Diameter As Object
    ' Gear M1 has a Gear and LineA and LineB
    ' Gear M1 has 96 teeth
    ' Gear M1 drives Shaft M1 (through main plate) to Gear M2 (15 teeth) in the Metonic (and Soros) chain

    ' Shaft M1
    ' Goes from M1 to M2 runs through Main Plate (do we need to show a hole/bearing in it?)
    ' Use Gear_M1_Centre_X
    ' Use Gear_M1_Centre_Y
    Private Property Shaft_M1_Diameter As Object
    ' diameter 4


    ' Gear M2
    ' This is driven by Shaft M1
    ' Initial position (trivial) set to 0
    ' Use Gear_M1_Centre_X 
    ' Use Gear_M1_Centre_Y 
    ' Use Gear_M1_Angle 
    Private Property Gear_M2_Diameter As Object
    ' Gear M2 has a Gear and LineA and LineB
    ' Gear M2 has 15 teeth
    ' Gear M2 drives Gear N1 (53) - on the Metonic Arm shaft - and thence to the panhelenic games chain


    ' Gear N1
    ' This is driven by Gear M2
    ' Initial position (trivial) set to 0
    Private Property Gear_N1_Centre_X As Object
    Private Property Gear_N1_Centre_Y As Object
    Private Property Gear_N1_Angle As Object
    Private Property Gear_N1_Diameter As Object
    ' Gear N1 has a Gear and LineA and LineB
    ' Gear N1 has 53 teeth
    ' Gear N1 drives Shaft N1 (through BACK plate) to the Metonic Arm

    ' Shaft N1
    ' Goes from N1 through Back Plate (do we need to show a hole/bearing in it?)
    ' Use Gear_N1_Centre_X
    ' Use Gear_N1_Centre_Y
    Private Property Shaft_N1_Diameter As Object
    ' diameter 4


    'Arm N1
    ' This is the Metonic arm
    ' It is directly linked to Shaft N1
    ' with no rotational ofset.
    ' use Gear_N1_Centre_X
    ' use Gear_N1_Centre_Y
    ' use Gear_N1_Angle
    Private Property Arm_N1_Length As Object
    Private Property Arm_N1_Tip_X As Object
    Private Property Arm_N1_Tip_Y As Object
    ' Arm N1 has itself only




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set up initial values and draw everything drawable and set the correct back to front sequence for visibility

        ' Set up locic variable
        Running = False
        Run_Once = True







        ' Set up components - from front backwards same order as we calculate them
        ' only set up non varying components here 
        ' variable components are set up by the calculate and draw mechanisms
        ' So fixed gears centres and diameters
        ' Arm lengths
        ' Movable Gears diameters
        ' Features (eg Sun, Moon) diameters or heights and widths

        ' Gear B1 - Main input Gear - parameters
        Gear_B1_Angle = 0
        Gear_B1_Centre_X = 180
        Gear_B1_Centre_Y = 340
        Gear_B1_Diameter = 258
        ' Model setup for Gear B1
        Gear_B1_Gear.Location = New System.Drawing.Point(Gear_B1_Centre_X - Gear_B1_Diameter / 2, Gear_B1_Centre_Y - Gear_B1_Diameter / 2)
        Gear_B1_Gear.Size = New System.Drawing.Point(Gear_B1_Diameter, Gear_B1_Diameter)


        ' Shaft B3
        Shaft_B3_Diameter = 4
        ' Model setup for Shaft B3
        Shaft_B3.Location = New System.Drawing.Point(Gear_B1_Centre_X - Shaft_B3_Diameter / 2, Gear_B1_Centre_Y - Shaft_B3_Diameter / 2)
        Shaft_B3.Size = New System.Drawing.Point(Shaft_B3_Diameter, Shaft_B3_Diameter)


        ' Arm B3 - Moon Arm
        ' on Shaft B3 - running inside pipe B1
        Arm_B3_Length = 146
        Moon.Size = New System.Drawing.Point(10, 10)
        Arm_B3.X1 = Gear_B1_Centre_X
        Arm_B3.Y1 = Gear_B1_Centre_Y
        Arm_B3.X2 = Gear_B1_Centre_X
        Arm_B3.Y2 = Gear_B1_Centre_Y - Arm_B3_Length


        ' Pipe B1
        Pipe_B1_Diameter = 12
        ' Model setup for Pipe B3
        Pipe_B1.Location = New System.Drawing.Point(Gear_B1_Centre_X - Pipe_B1_Diameter / 2, Gear_B1_Centre_Y - Pipe_B1_Diameter / 2)
        Pipe_B1.Size = New System.Drawing.Point(Pipe_B1_Diameter, Pipe_B1_Diameter)


        ' Arm B1 - Sun Arm 
        ' on Pipe B1 (as Moon Shaft B3 run up through it)
        Arm_B1_Length = 146
        Sun.Size = New System.Drawing.Point(10, 10)
        Arm_B1.X1 = Gear_B1_Centre_X
        Arm_B1.Y1 = Gear_B1_Centre_Y - Pipe_B1_Diameter / 2
        Arm_B1.X2 = Gear_B1_Centre_X
        Arm_B1.Y2 = Gear_B1_Centre_Y - Arm_B1_Length






        ' Front Plate
        ' With only the sun and moon arms in fron of it - uses a graphic
        FrontPlate.Location = New System.Drawing.Point(20, 20)
        FrontPlate.Size = New System.Drawing.Point(320, 620)




        ' Gear B2 - Main driving gear - driven by input - parameters
        Gear_B2_Diameter = 61
        ' Model setup for Gear B2
        Gear_B2_Gear.Location = New System.Drawing.Point(Gear_B1_Centre_X - Gear_B2_Diameter / 2, Gear_B1_Centre_Y - Gear_B2_Diameter / 2)
        Gear_B2_Gear.Size = New System.Drawing.Point(Gear_B2_Diameter, Gear_B2_Diameter)

        ' Gear C1 - driven gear by B2 - drives shaft to C2 - lunar
        Gear_C1_Centre_X = 168
        Gear_C1_Centre_Y = 389
        Gear_C1_Diameter = 39
        ' Model setup for Gear C1
        Gear_C1_Gear.Location = New System.Drawing.Point(Gear_C1_Centre_X - Gear_C1_Diameter / 2, Gear_C1_Centre_Y - Gear_C1_Diameter / 2)
        Gear_C1_Gear.Size = New System.Drawing.Point(Gear_C1_Diameter, Gear_C1_Diameter)


        ' Shaft C1
        Shaft_C1_Diameter = 4
        ' Model setup for Shaft C1
        Shaft_C1.Location = New System.Drawing.Point(Gear_C1_Centre_X - Shaft_C1_Diameter / 2, Gear_C1_Centre_Y - Shaft_C1_Diameter / 2)
        Shaft_C1.Size = New System.Drawing.Point(Shaft_C1_Diameter, Shaft_C1_Diameter)


        ' Gear L1 - driven gear by B2 - drives shaft to L2 - Metonic (and Saros)
        Gear_L1_Centre_X = 220
        Gear_L1_Centre_Y = 314
        Gear_L1_Diameter = 35
        ' Model setup for Gear L1
        Gear_L1_Gear.Location = New System.Drawing.Point(Gear_L1_Centre_X - Gear_L1_Diameter / 2, Gear_L1_Centre_Y - Gear_L1_Diameter / 2)
        Gear_L1_Gear.Size = New System.Drawing.Point(Gear_L1_Diameter, Gear_L1_Diameter)

        ' Shaft L1
        Shaft_L1_Diameter = 4
        ' Model setup for Shaft L1
        Shaft_L1.Location = New System.Drawing.Point(Gear_L1_Centre_X - Shaft_L1_Diameter / 2, Gear_L1_Centre_Y - Shaft_L1_Diameter / 2)
        Shaft_L1.Size = New System.Drawing.Point(Shaft_L1_Diameter, Shaft_L1_Diameter)


        ' Gear C2 - driven by shaft from C1 - drives gear D1 - lunar
        Gear_C2_Diameter = 43
        ' Model setup for Gear C2
        Gear_C2_Gear.Location = New System.Drawing.Point(Gear_C1_Centre_X - Gear_C2_Diameter / 2, Gear_C1_Centre_Y - Gear_C2_Diameter / 2)
        Gear_C2_Gear.Size = New System.Drawing.Point(Gear_C2_Diameter, Gear_C2_Diameter)



        ' Gear L2 - driven by shaft from L1 - drives gear M1 - Metonic (and Saros)
        Gear_L2_Diameter = 52
        ' Model setup for Gear L2
        Gear_L2_Gear.Location = New System.Drawing.Point(Gear_L1_Centre_X - Gear_L2_Diameter / 2, Gear_L1_Centre_Y - Gear_L2_Diameter / 2)
        Gear_L2_Gear.Size = New System.Drawing.Point(Gear_L2_Diameter, Gear_L2_Diameter)






        ' Gear D1 - driven gear by C2 - drives shaft to D2 - Lunar
        Gear_D1_Centre_X = 161
        Gear_D1_Centre_Y = 420
        Gear_D1_Diameter = 22
        ' Model setup for Gear D1
        Gear_D1_Gear.Location = New System.Drawing.Point(Gear_D1_Centre_X - Gear_D1_Diameter / 2, Gear_D1_Centre_Y - Gear_D1_Diameter / 2)
        Gear_D1_Gear.Size = New System.Drawing.Point(Gear_D1_Diameter, Gear_D1_Diameter)

        ' Shaft D1
        Shaft_D1_Diameter = 4
        ' Model setup for Shaft D1
        Shaft_D1.Location = New System.Drawing.Point(Gear_D1_Centre_X - Shaft_D1_Diameter / 2, Gear_D1_Centre_Y - Shaft_D1_Diameter / 2)
        Shaft_D1.Size = New System.Drawing.Point(Shaft_D1_Diameter, Shaft_D1_Diameter)




        ' Gear M1 - driven gear by L2 - drives shaft to M2 - Metonic(and Soros)
        Gear_M1_Centre_X = 180
        Gear_M1_Centre_Y = 251
        Gear_M1_Diameter = 97
        ' Model setup for Gear M1
        Gear_M1_Gear.Location = New System.Drawing.Point(Gear_M1_Centre_X - Gear_M1_Diameter / 2, Gear_M1_Centre_Y - Gear_M1_Diameter / 2)
        Gear_M1_Gear.Size = New System.Drawing.Point(Gear_M1_Diameter, Gear_M1_Diameter)

        ' Shaft M1
        Shaft_M1_Diameter = 4
        ' Model setup for Shaft M1
        Shaft_M1.Location = New System.Drawing.Point(Gear_M1_Centre_X - Shaft_M1_Diameter / 2, Gear_M1_Centre_Y - Shaft_M1_Diameter / 2)
        Shaft_M1.Size = New System.Drawing.Point(Shaft_M1_Diameter, Shaft_M1_Diameter)


        ' Main Plate
        ' Main Drive : B1, B2 in front - Shaft B1 (moon) and Pipe B1 (Sun) go through it (to B3 below)
        ' Lunar Cycle : B1, B2, C1, C2, D1 - in front - shaft D goes through it (to D2 delow)
        ' Metonic etc cycle ...... in front 
        MainPlate.Location = New System.Drawing.Point(20, 20)
        MainPlate.Size = New System.Drawing.Point(320, 620)


        ' Gear D2 - driven by shaft from D1 - drives gear E2 - lunar
        Gear_D2_Diameter = 124
        ' Model setup for Gear D2
        Gear_D2_Gear.Location = New System.Drawing.Point(Gear_D1_Centre_X - Gear_D2_Diameter / 2, Gear_D1_Centre_Y - Gear_D2_Diameter / 2)
        Gear_D2_Gear.Size = New System.Drawing.Point(Gear_D2_Diameter, Gear_D2_Diameter)


        ' Gear M2 - driven by shaft from M1 - drives gear N1 - Metonic(and Soros)
        Gear_M2_Diameter = 15
        ' Model setup for Gear M2
        Gear_M2_Gear.Location = New System.Drawing.Point(Gear_M1_Centre_X - Gear_M2_Diameter / 2, Gear_M1_Centre_Y - Gear_M2_Diameter / 2)
        Gear_M2_Gear.Size = New System.Drawing.Point(Gear_M2_Diameter, Gear_M2_Diameter)



        ' Gear N1 - driven gear by M2 - drives shaft to Metonic Arm
        Gear_N1_Centre_X = 180
        Gear_N1_Centre_Y = 218
        Gear_N1_Diameter = 52
        ' Model setup for Gear N1
        Gear_N1_Gear.Location = New System.Drawing.Point(Gear_N1_Centre_X - Gear_N1_Diameter / 2, Gear_N1_Centre_Y - Gear_N1_Diameter / 2)
        Gear_N1_Gear.Size = New System.Drawing.Point(Gear_N1_Diameter, Gear_N1_Diameter)

        ' Shaft N1
        Shaft_N1_Diameter = 4
        ' Model setup for Shaft N1
        Shaft_N1.Location = New System.Drawing.Point(Gear_N1_Centre_X - Shaft_N1_Diameter / 2, Gear_N1_Centre_Y - Shaft_N1_Diameter / 2)
        Shaft_N1.Size = New System.Drawing.Point(Shaft_N1_Diameter, Shaft_N1_Diameter)


        ' Back Plate
        ' With only the back arms behind it 
        BackPlate.Location = New System.Drawing.Point(20, 20)
        BackPlate.Size = New System.Drawing.Point(320, 620)


        ' Arm N1 - Metonic Arm
        ' on Shaft N1
        Arm_N1_Length = 146

        Arm_N1.X1 = Gear_N1_Centre_X
        Arm_N1.Y1 = Gear_N1_Centre_Y
        Arm_N1.X2 = Gear_N1_Centre_X
        Arm_N1.Y2 = Gear_N1_Centre_Y - Arm_N1_Length




        ' Build and order components - from the back forward



        ' Arm N1
        Arm_N1.BringToFront()
        Arm_N1.Visible = True
        Arm_N1_Check.Checked = True


        'Back Plate
        BackPlate.BringToFront()
        BackPlate.Visible = True
        BackPlate_Check.Checked = True


        ' Gear N1
        Gear_N1_Gear.BringToFront()
        Gear_N1_Gear.Visible = True
        Gear_N1_LineA.BringToFront()
        Gear_N1_LineA.Visible = True
        Gear_N1_LineB.BringToFront()
        Gear_N1_LineB.Visible = True
        Gear_N1_Check.Checked = True

        ' Shaft N1
        Shaft_N1.BringToFront()
        Shaft_N1.Visible = True

        ' Gear M2
        Gear_M2_Gear.BringToFront()
        Gear_M2_Gear.Visible = True
        Gear_M2_LineA.BringToFront()
        Gear_M2_LineA.Visible = True
        Gear_M2_LineB.BringToFront()
        Gear_M2_LineB.Visible = True
        Gear_M2_Check.Checked = True


        ' Gear D2
        Gear_D2_Gear.BringToFront()
        Gear_D2_Gear.Visible = True
        Gear_D2_LineA.BringToFront()
        Gear_D2_LineA.Visible = True
        Gear_D2_LineB.BringToFront()
        Gear_D2_LineB.Visible = True
        Gear_D2_Check.Checked = True


        'Main Plate
        MainPlate.BringToFront()
        MainPlate.Visible = True
        MainPlate_Check.Checked = True


        ' Gear M1
        Gear_M1_Gear.BringToFront()
        Gear_M1_Gear.Visible = True
        Gear_M1_LineA.BringToFront()
        Gear_M1_LineA.Visible = True
        Gear_M1_LineB.BringToFront()
        Gear_M1_LineB.Visible = True
        Gear_M1_Check.Checked = True


        ' Shaft M1
        Shaft_M1.BringToFront()
        Shaft_M1.Visible = True


        ' Gear D1
        Gear_D1_Gear.BringToFront()
        Gear_D1_Gear.Visible = True
        Gear_D1_LineA.BringToFront()
        Gear_D1_LineA.Visible = True
        Gear_D1_LineB.BringToFront()
        Gear_D1_LineB.Visible = True
        Gear_D1_Check.Checked = True


        ' Shaft D1
        Shaft_D1.BringToFront()
        Shaft_D1.Visible = True


        ' Gear L2
        Gear_L2_Gear.BringToFront()
        Gear_L2_Gear.Visible = True
        Gear_L2_LineA.BringToFront()
        Gear_L2_LineA.Visible = True
        Gear_L2_LineB.BringToFront()
        Gear_L2_LineB.Visible = True
        Gear_L2_Check.Checked = True


        ' Gear C2
        Gear_C2_Gear.BringToFront()
        Gear_C2_Gear.Visible = True
        Gear_C2_LineA.BringToFront()
        Gear_C2_LineA.Visible = True
        Gear_C2_LineB.BringToFront()
        Gear_C2_LineB.Visible = True
        Gear_C2_Check.Checked = True


        ' Gear L1
        Gear_L1_Gear.BringToFront()
        Gear_L1_Gear.Visible = True
        Gear_L1_LineA.BringToFront()
        Gear_L1_LineA.Visible = True
        Gear_L1_LineB.BringToFront()
        Gear_L1_LineB.Visible = True
        Gear_L1_Check.Checked = True


        ' Shaft L1
        Shaft_L1.BringToFront()
        Shaft_L1.Visible = True



        ' Gear C1
        Gear_C1_Gear.BringToFront()
        Gear_C1_Gear.Visible = True
        Gear_C1_LineA.BringToFront()
        Gear_C1_LineA.Visible = True
        Gear_C1_LineB.BringToFront()
        Gear_C1_LineB.Visible = True
        Gear_C1_Check.Checked = True

        ' Shaft C1
        Shaft_C1.BringToFront()
        Shaft_C1.Visible = True


        ' Gear B2
        Gear_B2_Gear.BringToFront()
        Gear_B2_Gear.Visible = True
        Gear_B2_LineA.BringToFront()
        Gear_B2_LineA.Visible = True
        Gear_B2_LineB.BringToFront()
        Gear_B2_LineB.Visible = True
        Gear_B2_Check.Checked = True


        ' Gear B1
        Gear_B1_Gear.BringToFront()
        Gear_B1_Gear.Visible = True
        Gear_B1_LineA.BringToFront()
        Gear_B1_LineA.Visible = True
        Gear_B1_LineB.BringToFront()
        Gear_B1_LineB.Visible = True
        Gear_B1_Check.Checked = True


        'Front Plate
        FrontPlate.BringToFront()
        FrontPlate.Visible = True
        FrontPlate_Check.Checked = True


        ' Pipe_B1
        Pipe_B1.BringToFront()
        Pipe_B1.Visible = True


        ' Arm B1  - Sun Arm (Or calendar arm?)
        Arm_B1.BringToFront()
        Arm_B1.Visible = True
        Sun.BringToFront()
        Sun.Visible = True
        Arm_B1_Check.Checked = True


        ' Shaft B3
        Shaft_B3.BringToFront()
        Shaft_B3.Visible = True

        ' Arm B3 - Moon Arm
        Arm_B3.BringToFront()
        Arm_B3.Visible = True
        Moon.BringToFront()
        Moon.Visible = True
        Arm_B3_Check.Checked = True


        Timer1.Enabled = True


    End Sub





    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' on each timer tick increment the angle of the Gear B1 clockwise by 1 day (360/365.25 of a degree)
        ' then follow through the sequence of shafts and gears to implement their rotation
        ' ignoring the lunar anomaly mechanism.
        ' then set the atributes of the graphics components so that the display changes.

        ' temp reduce increment angle substantially to see if movement is smoother 1/24 (1 hour) 

        'check for running status either continuous or once
        If Running Or Run_Once Then
            'Gear B1 - input
            Gear_B1_Angle = Gear_B1_Angle + ((Math.PI / 180) * (360 / 365.25)) ' / 24
            Gear_B1_Text.Text = Gear_B1_Angle
            ' and turn of single tic
            Run_Once = False
        End If


        ' Gear C1 - driven by Gear B2 (same angle as B1)
        ' Ratio is B2=64 C1=38
        Gear_C1_Angle = Gear_B1_Angle * (64 / 38) * -1
        Gear_C1_Text.Text = Gear_C1_Angle

        ' Gear L1 - driven by Gear B2 (same angle as B1)
        ' Ratio is B2=64 L1=38
        Gear_L1_Angle = Gear_B1_Angle * (64 / 38) * -1
        Gear_L1_Text.Text = Gear_L1_Angle

        ' Gear D1 - driven by Gear C2 (same angle as C1) 
        ' Ratio is C2=48 D1=24
        Gear_D1_Angle = Gear_C1_Angle * (48 / 24) * -1
        Gear_D1_Text.Text = Gear_D1_Angle


        ' Gear M1 - driven by Gear L2 (same angle as L1) 
        ' Ratio is L2=53 M1=96
        Gear_M1_Angle = Gear_L1_Angle * (53 / 96) * -1
        Gear_M1_Text.Text = Gear_M1_Angle

        ' Gear N1 - driven by Gear M2 (same angle as M1) 
        ' Ratio is M2=15 N1=53
        Gear_N1_Angle = Gear_M1_Angle * (15 / 53) * -1
        Gear_N1_Text.Text = Gear_N1_Angle



        ' Temporary fix to get moon arm working
        ' ratio 254/19 to sun arm same direction
        Gear_B3_Angle = Gear_B1_Angle * (254 / 19)


        ' Gear B1 moved so recalculate all fixed objects

        ' Gear B1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines
        ' Only Calculate if Gear is Visible
        ' It's behind the Front Plate
        If Gear_B1_Gear.Visible = False Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear B1 - Line A
            Temp_X = Math.Sin(Gear_B1_Angle)
            Temp_Y = Math.Cos(Gear_B1_Angle)
            Gear_B1_LineA.X1 = Temp_X * (Gear_B1_Diameter / 4) + Gear_B1_Centre_X
            Gear_B1_LineA.Y1 = Gear_B1_Centre_Y - Temp_Y * (Gear_B1_Diameter / 4)
            Temp_X = Math.Sin(Gear_B1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_B1_Angle + Math.PI)
            Gear_B1_LineA.X2 = Temp_X * (Gear_B1_Diameter / 4) + Gear_B1_Centre_X
            Gear_B1_LineA.Y2 = Gear_B1_Centre_Y - Temp_Y * (Gear_B1_Diameter / 4)

            ' Gear B1 - Line B
            Temp_X = Math.Sin(Gear_B1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_B1_Angle + Math.PI / 2)
            Gear_B1_LineB.X1 = Temp_X * (Gear_B1_Diameter / 4) + Gear_B1_Centre_X
            Gear_B1_LineB.Y1 = Gear_B1_Centre_Y - Temp_Y * (Gear_B1_Diameter / 4)
            Temp_X = Math.Sin(Gear_B1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_B1_Angle + 3 * Math.PI / 2)
            Gear_B1_LineB.X2 = Temp_X * (Gear_B1_Diameter / 4) + Gear_B1_Centre_X
            Gear_B1_LineB.Y2 = Gear_B1_Centre_Y - Temp_Y * (Gear_B1_Diameter / 4)
        End If


        ' Arm B1:
        ' This arm is attached to Pipe B1
        ' It tracks the movement of the Sun in the sky against the backdrop of the Zodiak stars
        ' 1 revolution per year (exactly which year remains to be seen) 
        ' Only calculate if arm is visble
        ' it's out in front so only it's own visibility matters
        If Arm_B1.Visible Then
            Temp_X = Math.Sin(Gear_B1_Angle)
            Temp_Y = Math.Cos(Gear_B1_Angle)
            ' TextBox1.Text = Temp_X
            ' TextBox2.Text = Temp_Y
            'Starts on Pipe B1 so start at the edge of the pipe
            Arm_B1.X1 = Temp_X * Pipe_B1_Diameter / 2 + Gear_B1_Centre_X
            Arm_B1.Y1 = Gear_B1_Centre_Y - Temp_Y * Pipe_B1_Diameter / 2
            ' now the outer end - use a variable so we can hang the sun on it
            Arm_B1_Tip_X = Temp_X * Arm_B1_Length + Gear_B1_Centre_X
            Arm_B1_Tip_Y = Gear_B1_Centre_Y - Temp_Y * Arm_B1_Length
            Arm_B1.X2 = Arm_B1_Tip_X
            Arm_B1.Y2 = Arm_B1_Tip_Y
            ' TextBox3.Text = Arm_B1.X2
            ' TextBox4.Text = Arm_B1.Y2
            ' Sun.Location = Arm_B1_Tip_X - 5
            ' Sun.Location = Arm_B1_Tip_Y - 5
            Sun.Location = New System.Drawing.Point(Arm_B1_Tip_X - 5, Arm_B1_Tip_Y - 5)
        End If


        ' Gear B2
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind Gear B1 and the Front Plate

        If Gear_B2_Gear.Visible = False Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear B2 - Line A
            Temp_X = Math.Sin(Gear_B1_Angle)
            Temp_Y = Math.Cos(Gear_B1_Angle)
            Gear_B2_LineA.X1 = Temp_X * (Gear_B2_Diameter / 4) + Gear_B1_Centre_X
            Gear_B2_LineA.Y1 = Gear_B1_Centre_Y - Temp_Y * (Gear_B2_Diameter / 4)
            Temp_X = Math.Sin(Gear_B1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_B1_Angle + Math.PI)
            Gear_B2_LineA.X2 = Temp_X * (Gear_B2_Diameter / 4) + Gear_B1_Centre_X
            Gear_B2_LineA.Y2 = Gear_B1_Centre_Y - Temp_Y * (Gear_B2_Diameter / 4)
            ' Gear B1 - Line B
            Temp_X = Math.Sin(Gear_B1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_B1_Angle + Math.PI / 2)
            Gear_B2_LineB.X1 = Temp_X * (Gear_B2_Diameter / 4) + Gear_B1_Centre_X
            Gear_B2_LineB.Y1 = Gear_B1_Centre_Y - Temp_Y * (Gear_B2_Diameter / 4)
            Temp_X = Math.Sin(Gear_B1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_B1_Angle + 3 * Math.PI / 2)
            Gear_B2_LineB.X2 = Temp_X * (Gear_B2_Diameter / 4) + Gear_B1_Centre_X
            Gear_B2_LineB.Y2 = Gear_B1_Centre_Y - Temp_Y * (Gear_B2_Diameter / 4)
        End If


        ' Pipe B1
        ' visible if sun arm, front plate, B1 or B3 are visible - 
        ' Otherwise not
        If Arm_B1.Visible Or FrontPlate.Visible Or Gear_B1_Gear.Visible Or Gear_B2_Gear.Visible Then
            Pipe_B1.Visible = True
        Else
            Pipe_B1.Visible = False
        End If



        ' Gear C1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind B1 and the Front Plate
        If Gear_C1_Gear.Visible = False Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear C1 - Line A
            Temp_X = Math.Sin(Gear_C1_Angle)
            Temp_Y = Math.Cos(Gear_C1_Angle)
            Gear_C1_LineA.X1 = Temp_X * (Gear_C1_Diameter / 4) + Gear_C1_Centre_X
            Gear_C1_LineA.Y1 = Gear_C1_Centre_Y - Temp_Y * (Gear_C1_Diameter / 4)
            Temp_X = Math.Sin(Gear_C1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_C1_Angle + Math.PI)
            Gear_C1_LineA.X2 = Temp_X * (Gear_C1_Diameter / 4) + Gear_C1_Centre_X
            Gear_C1_LineA.Y2 = Gear_C1_Centre_Y - Temp_Y * (Gear_C1_Diameter / 4)

            ' Gear C1 - Line B
            Temp_X = Math.Sin(Gear_C1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_C1_Angle + Math.PI / 2)
            Gear_C1_LineB.X1 = Temp_X * (Gear_C1_Diameter / 4) + Gear_C1_Centre_X
            Gear_C1_LineB.Y1 = Gear_C1_Centre_Y - Temp_Y * (Gear_C1_Diameter / 4)
            Temp_X = Math.Sin(Gear_C1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_C1_Angle + 3 * Math.PI / 2)
            Gear_C1_LineB.X2 = Temp_X * (Gear_C1_Diameter / 4) + Gear_C1_Centre_X
            Gear_C1_LineB.Y2 = Gear_C1_Centre_Y - Temp_Y * (Gear_C1_Diameter / 4)
        End If


        ' Gear L1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind B1 and the Front Plate
        If Gear_L1_Gear.Visible = False Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear L1 - Line A
            Temp_X = Math.Sin(Gear_L1_Angle)
            Temp_Y = Math.Cos(Gear_L1_Angle)
            Gear_L1_LineA.X1 = Temp_X * (Gear_L1_Diameter / 4) + Gear_L1_Centre_X
            Gear_L1_LineA.Y1 = Gear_L1_Centre_Y - Temp_Y * (Gear_L1_Diameter / 4)
            Temp_X = Math.Sin(Gear_L1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_L1_Angle + Math.PI)
            Gear_L1_LineA.X2 = Temp_X * (Gear_L1_Diameter / 4) + Gear_L1_Centre_X
            Gear_L1_LineA.Y2 = Gear_L1_Centre_Y - Temp_Y * (Gear_L1_Diameter / 4)

            ' Gear C1 - Line B
            Temp_X = Math.Sin(Gear_L1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_L1_Angle + Math.PI / 2)
            Gear_L1_LineB.X1 = Temp_X * (Gear_L1_Diameter / 4) + Gear_L1_Centre_X
            Gear_L1_LineB.Y1 = Gear_L1_Centre_Y - Temp_Y * (Gear_L1_Diameter / 4)
            Temp_X = Math.Sin(Gear_L1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_L1_Angle + 3 * Math.PI / 2)
            Gear_L1_LineB.X2 = Temp_X * (Gear_L1_Diameter / 4) + Gear_L1_Centre_X
            Gear_L1_LineB.Y2 = Gear_L1_Centre_Y - Temp_Y * (Gear_L1_Diameter / 4)
        End If






        ' Gear C2
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind C1, B1 and the Front Plate (but larger than C1 - but not enough for the animations to show)
        If Gear_C2_Gear.Visible = False Or Gear_C1_Gear.Visible Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear C2 - Line A
            Temp_X = Math.Sin(Gear_C1_Angle)
            Temp_Y = Math.Cos(Gear_C1_Angle)
            Gear_C2_LineA.X1 = Temp_X * (Gear_C2_Diameter / 4) + Gear_C1_Centre_X
            Gear_C2_LineA.Y1 = Gear_C1_Centre_Y - Temp_Y * (Gear_C2_Diameter / 4)
            Temp_X = Math.Sin(Gear_C1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_C1_Angle + Math.PI)
            Gear_C2_LineA.X2 = Temp_X * (Gear_C2_Diameter / 4) + Gear_C1_Centre_X
            Gear_C2_LineA.Y2 = Gear_C1_Centre_Y - Temp_Y * (Gear_C2_Diameter / 4)

            ' Gear C1 - Line B
            Temp_X = Math.Sin(Gear_C1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_C1_Angle + Math.PI / 2)
            Gear_C2_LineB.X1 = Temp_X * (Gear_C2_Diameter / 4) + Gear_C1_Centre_X
            Gear_C2_LineB.Y1 = Gear_C1_Centre_Y - Temp_Y * (Gear_C2_Diameter / 4)
            Temp_X = Math.Sin(Gear_C1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_C1_Angle + 3 * Math.PI / 2)
            Gear_C2_LineB.X2 = Temp_X * (Gear_C2_Diameter / 4) + Gear_C1_Centre_X
            Gear_C2_LineB.Y2 = Gear_C1_Centre_Y - Temp_Y * (Gear_C2_Diameter / 4)
        End If


        ' Gear L2
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind L1, B1 and the Front Plate  (but larger than L1 - but not enough for the animations to show)
        If Gear_L2_Gear.Visible = False Or Gear_L1_Gear.Visible Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear L2 - Line A
            Temp_X = Math.Sin(Gear_L1_Angle)
            Temp_Y = Math.Cos(Gear_L1_Angle)
            Gear_L2_LineA.X1 = Temp_X * (Gear_L2_Diameter / 4) + Gear_L1_Centre_X
            Gear_L2_LineA.Y1 = Gear_L1_Centre_Y - Temp_Y * (Gear_L2_Diameter / 4)
            Temp_X = Math.Sin(Gear_L1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_L1_Angle + Math.PI)
            Gear_L2_LineA.X2 = Temp_X * (Gear_L2_Diameter / 4) + Gear_L1_Centre_X
            Gear_L2_LineA.Y2 = Gear_L1_Centre_Y - Temp_Y * (Gear_L2_Diameter / 4)

            ' Gear L1 - Line B
            Temp_X = Math.Sin(Gear_L1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_L1_Angle + Math.PI / 2)
            Gear_L2_LineB.X1 = Temp_X * (Gear_L2_Diameter / 4) + Gear_L1_Centre_X
            Gear_L2_LineB.Y1 = Gear_L1_Centre_Y - Temp_Y * (Gear_L2_Diameter / 4)
            Temp_X = Math.Sin(Gear_L1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_L1_Angle + 3 * Math.PI / 2)
            Gear_L2_LineB.X2 = Temp_X * (Gear_L2_Diameter / 4) + Gear_L1_Centre_X
            Gear_L2_LineB.Y2 = Gear_L1_Centre_Y - Temp_Y * (Gear_L2_Diameter / 4)
        End If








        ' Gear D1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind B1 and the Front Plate
        If Gear_D1_Gear.Visible = False Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear D1 - Line A
            Temp_X = Math.Sin(Gear_D1_Angle)
            Temp_Y = Math.Cos(Gear_D1_Angle)
            Gear_D1_LineA.X1 = Temp_X * (Gear_D1_Diameter / 4) + Gear_D1_Centre_X
            Gear_D1_LineA.Y1 = Gear_D1_Centre_Y - Temp_Y * (Gear_D1_Diameter / 4)
            Temp_X = Math.Sin(Gear_D1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_D1_Angle + Math.PI)
            Gear_D1_LineA.X2 = Temp_X * (Gear_D1_Diameter / 4) + Gear_D1_Centre_X
            Gear_D1_LineA.Y2 = Gear_D1_Centre_Y - Temp_Y * (Gear_D1_Diameter / 4)

            ' Gear D1 - Line B
            Temp_X = Math.Sin(Gear_D1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_D1_Angle + Math.PI / 2)
            Gear_D1_LineB.X1 = Temp_X * (Gear_D1_Diameter / 4) + Gear_D1_Centre_X
            Gear_D1_LineB.Y1 = Gear_D1_Centre_Y - Temp_Y * (Gear_D1_Diameter / 4)
            Temp_X = Math.Sin(Gear_D1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_D1_Angle + 3 * Math.PI / 2)
            Gear_D1_LineB.X2 = Temp_X * (Gear_D1_Diameter / 4) + Gear_D1_Centre_X
            Gear_D1_LineB.Y2 = Gear_D1_Centre_Y - Temp_Y * (Gear_D1_Diameter / 4)
        End If


        ' Gear M1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind B1 (enough to not need animation) and the Front Plate
        If Gear_M1_Gear.Visible = False Or Gear_B1_Gear.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear M1 - Line A
            Temp_X = Math.Sin(Gear_M1_Angle)
            Temp_Y = Math.Cos(Gear_M1_Angle)
            Gear_M1_LineA.X1 = Temp_X * (Gear_M1_Diameter / 4) + Gear_M1_Centre_X
            Gear_M1_LineA.Y1 = Gear_M1_Centre_Y - Temp_Y * (Gear_M1_Diameter / 4)
            Temp_X = Math.Sin(Gear_M1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_M1_Angle + Math.PI)
            Gear_M1_LineA.X2 = Temp_X * (Gear_M1_Diameter / 4) + Gear_M1_Centre_X
            Gear_M1_LineA.Y2 = Gear_M1_Centre_Y - Temp_Y * (Gear_M1_Diameter / 4)

            ' Gear D1 - Line B
            Temp_X = Math.Sin(Gear_M1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_M1_Angle + Math.PI / 2)
            Gear_M1_LineB.X1 = Temp_X * (Gear_M1_Diameter / 4) + Gear_M1_Centre_X
            Gear_M1_LineB.Y1 = Gear_M1_Centre_Y - Temp_Y * (Gear_M1_Diameter / 4)
            Temp_X = Math.Sin(Gear_M1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_M1_Angle + 3 * Math.PI / 2)
            Gear_M1_LineB.X2 = Temp_X * (Gear_M1_Diameter / 4) + Gear_M1_Centre_X
            Gear_M1_LineB.Y2 = Gear_M1_Centre_Y - Temp_Y * (Gear_M1_Diameter / 4)
        End If





        ' Shafts mounted on main plate (only visible if main plate is visible
        ' and if not covered by objects in front of them

        ' Shaft C1
        ' Visible if Main Plate or either gears C1, C2 is visible
        ' Object draw sequence hides it if objects in front of it are visible
        If MainPlate.Visible Or Gear_C1_Gear.Visible Or Gear_C2_Gear.Visible Then
            Shaft_C1.Visible = True
        Else
            Shaft_C1.Visible = False
        End If


        ' Shaft L1
        ' Visible if Main Plate or either gears L1, L2 is visible
        ' Object draw sequence hides it if objects in front of it are visible
        If MainPlate.Visible Or Gear_L1_Gear.Visible Or Gear_L2_Gear.Visible Then
            Shaft_L1.Visible = True
        Else
            Shaft_L1.Visible = False
        End If

       


        ' ***********************************************************
        '      End of Objects in front of main plate
        ' ***********************************************************

        ' Gear D2
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind the Main Plate and the Front Plate - and almost hidden under B1
        If Gear_D2_Gear.Visible = False Or Gear_B1_Gear.Visible Or MainPlate.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear D2 - Line A
            Temp_X = Math.Sin(Gear_D1_Angle)
            Temp_Y = Math.Cos(Gear_D1_Angle)
            Gear_D2_LineA.X1 = Temp_X * (Gear_D2_Diameter / 4) + Gear_D1_Centre_X
            Gear_D2_LineA.Y1 = Gear_D1_Centre_Y - Temp_Y * (Gear_D2_Diameter / 4)
            Temp_X = Math.Sin(Gear_D1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_D1_Angle + Math.PI)
            Gear_D2_LineA.X2 = Temp_X * (Gear_D2_Diameter / 4) + Gear_D1_Centre_X
            Gear_D2_LineA.Y2 = Gear_D1_Centre_Y - Temp_Y * (Gear_D2_Diameter / 4)

            ' Gear D2 - Line B
            Temp_X = Math.Sin(Gear_D1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_D1_Angle + Math.PI / 2)
            Gear_D2_LineB.X1 = Temp_X * (Gear_D2_Diameter / 4) + Gear_D1_Centre_X
            Gear_D2_LineB.Y1 = Gear_D1_Centre_Y - Temp_Y * (Gear_D2_Diameter / 4)
            Temp_X = Math.Sin(Gear_D1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_D1_Angle + 3 * Math.PI / 2)
            Gear_D2_LineB.X2 = Temp_X * (Gear_D2_Diameter / 4) + Gear_D1_Centre_X
            Gear_D2_LineB.Y2 = Gear_D1_Centre_Y - Temp_Y * (Gear_D2_Diameter / 4)
        End If



        ' Gear M2
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind the Main Plate and the Front Plate - and hidden under B1 and M1
        If Gear_M2_Gear.Visible = False Or Gear_M1_Gear.Visible Or Gear_B1_Gear.Visible Or MainPlate.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            ' Gear M2 - Line A
            Temp_X = Math.Sin(Gear_M1_Angle)
            Temp_Y = Math.Cos(Gear_M1_Angle)
            Gear_M2_LineA.X1 = Temp_X * (Gear_M2_Diameter / 4) + Gear_M1_Centre_X
            Gear_M2_LineA.Y1 = Gear_M1_Centre_Y - Temp_Y * (Gear_M2_Diameter / 4)
            Temp_X = Math.Sin(Gear_M1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_M1_Angle + Math.PI)
            Gear_M2_LineA.X2 = Temp_X * (Gear_M2_Diameter / 4) + Gear_M1_Centre_X
            Gear_M2_LineA.Y2 = Gear_M1_Centre_Y - Temp_Y * (Gear_M2_Diameter / 4)

            ' Gear M2 - Line B
            Temp_X = Math.Sin(Gear_M1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_M1_Angle + Math.PI / 2)
            Gear_M2_LineB.X1 = Temp_X * (Gear_M2_Diameter / 4) + Gear_M1_Centre_X
            Gear_M2_LineB.Y1 = Gear_M1_Centre_Y - Temp_Y * (Gear_M2_Diameter / 4)
            Temp_X = Math.Sin(Gear_M1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_M1_Angle + 3 * Math.PI / 2)
            Gear_M2_LineB.X2 = Temp_X * (Gear_M2_Diameter / 4) + Gear_M1_Centre_X
            Gear_M2_LineB.Y2 = Gear_M1_Centre_Y - Temp_Y * (Gear_M2_Diameter / 4)
        End If



        ' Gear N1
        ' Only rotate the lines as visible cues 
        ' Calculate the two ends of the A and B lines

        ' Only calculate/move if gear is visible
        ' it's behind M1 (enough to not need animation) and the Main and Front Plates
        If Gear_N1_Gear.Visible = False Or Gear_M1_Gear.Visible Or FrontPlate.Visible Or MainPlate.Visible Then
            ' do noting
        Else
            ' Gear N1 - Line A
            Temp_X = Math.Sin(Gear_N1_Angle)
            Temp_Y = Math.Cos(Gear_N1_Angle)
            Gear_N1_LineA.X1 = Temp_X * (Gear_N1_Diameter / 4) + Gear_N1_Centre_X
            Gear_N1_LineA.Y1 = Gear_N1_Centre_Y - Temp_Y * (Gear_N1_Diameter / 4)
            Temp_X = Math.Sin(Gear_N1_Angle + Math.PI)
            Temp_Y = Math.Cos(Gear_N1_Angle + Math.PI)
            Gear_N1_LineA.X2 = Temp_X * (Gear_N1_Diameter / 4) + Gear_N1_Centre_X
            Gear_N1_LineA.Y2 = Gear_N1_Centre_Y - Temp_Y * (Gear_N1_Diameter / 4)

            ' Gear D1 - Line B
            Temp_X = Math.Sin(Gear_N1_Angle + Math.PI / 2)
            Temp_Y = Math.Cos(Gear_N1_Angle + Math.PI / 2)
            Gear_N1_LineB.X1 = Temp_X * (Gear_N1_Diameter / 4) + Gear_N1_Centre_X
            Gear_N1_LineB.Y1 = Gear_N1_Centre_Y - Temp_Y * (Gear_N1_Diameter / 4)
            Temp_X = Math.Sin(Gear_N1_Angle + 3 * Math.PI / 2)
            Temp_Y = Math.Cos(Gear_N1_Angle + 3 * Math.PI / 2)
            Gear_N1_LineB.X2 = Temp_X * (Gear_N1_Diameter / 4) + Gear_N1_Centre_X
            Gear_N1_LineB.Y2 = Gear_N1_Centre_Y - Temp_Y * (Gear_N1_Diameter / 4)
        End If


        ' Shafts mounted on back plate (only visible if back plate is visible
        ' and if not covered by objects in front of them

        ' Shaft N1
        ' Visible if Back Plate or gear N1 is visible (and N2 if coded)
        ' Object draw sequence hides it if objects in front of it are visible
        If BackPlate.Visible Or Gear_N1_Gear.Visible Then
            Shaft_N1.Visible = True
        Else
            Shaft_N1.Visible = False
        End If



        ' Arm N1 - Metonic Arm
        ' This arm is attached to Shaft N1
        ' It tracks the Metonic Cycle in a 5 cycle spiral track on the back plate
        ' Only calculate if arm is visble
        ' It's behind all the plates so check the arm and the plates' visibility
        If Arm_N1.Visible = False Or BackPlate.Visible Or MainPlate.Visible Or FrontPlate.Visible Then
            ' do noting
        Else
            Temp_X = Math.Sin(Gear_N1_Angle)
            Temp_Y = Math.Cos(Gear_N1_Angle)
            'Starts on Shaft N1 
            ' now the outer end - use a variable so we can hang a pointer on it later
            Arm_N1_Tip_X = Temp_X * Arm_N1_Length + Gear_N1_Centre_X
            Arm_N1_Tip_Y = Gear_N1_Centre_Y - Temp_Y * Arm_N1_Length
            Arm_N1.X2 = Arm_N1_Tip_X
            Arm_N1.Y2 = Arm_N1_Tip_Y
        End If






        ' Arm B3:
        ' This arm is attached to Shaft B3
        ' It tracks the movement of the Moon in the sky against the backdrop of the Zodiak stars
        ' 254 revolutions per 19 years (exactly which year remains to be seen) 
        If Arm_B3.Visible Then
            Temp_X = Math.Sin(Gear_B3_Angle)
            Temp_Y = Math.Cos(Gear_B3_Angle)
            Arm_B3_Tip_X = Temp_X * Arm_B3_Length + Gear_B1_Centre_X
            Arm_B3_Tip_Y = Gear_B1_Centre_Y - Temp_Y * Arm_B3_Length
            Arm_B3.X2 = Arm_B3_Tip_X
            Arm_B3.Y2 = Arm_B3_Tip_Y
            Moon.Location = New System.Drawing.Point(Arm_B3_Tip_X - 5, Arm_B3_Tip_Y - 5)
        End If


    End Sub





    Private Sub Start_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start_Button.Click
        If Start_Button.Text = "Start" Then
            Running = True
            Start_Button.Text = "Stop"
        Else
            Running = False
            Start_Button.Text = "Start"
        End If
    End Sub

    Public Sub DrawMechanism()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub Arm_B3_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arm_B3_Check.CheckedChanged
        If Arm_B3_Check.Checked = True Then
            Arm_B3.Visible = True
            Moon.Visible = True
        Else
            Arm_B3.Visible = False
            Moon.Visible = False
        End If
    End Sub



    Private Sub Arm_B1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arm_B1_Check.CheckedChanged
        If Arm_B1_Check.Checked = True Then
            Arm_B1.Visible = True
            Sun.Visible = True
        Else
            Arm_B1.Visible = False
            Sun.Visible = False
        End If
    End Sub



    Private Sub FrontPlate_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrontPlate_Check.CheckedChanged
        If FrontPlate_Check.Checked = True Then
            FrontPlate.Visible = True
        Else
            FrontPlate.Visible = False
        End If
    End Sub



    Private Sub Gear_B1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_B1_Check.CheckedChanged
        If Gear_B1_Check.Checked = True Then
            Gear_B1_Gear.Visible = True
            Gear_B1_LineA.Visible = True
            Gear_B1_LineB.Visible = True
        Else
            Gear_B1_Gear.Visible = False
            Gear_B1_LineA.Visible = False
            Gear_B1_LineB.Visible = False
        End If
    End Sub



    Private Sub Gear_B2_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_B2_Check.CheckedChanged
        If Gear_B2_Check.Checked = True Then
            Gear_B2_Gear.Visible = True
            Gear_B2_LineA.Visible = True
            Gear_B2_LineB.Visible = True
        Else
            Gear_B2_Gear.Visible = False
            Gear_B2_LineA.Visible = False
            Gear_B2_LineB.Visible = False

        End If
    End Sub



    Private Sub Gear_C1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_C1_Check.CheckedChanged
        If Gear_C1_Check.Checked = True Then
            Gear_C1_Gear.Visible = True
            Gear_C1_LineA.Visible = True
            Gear_C1_LineB.Visible = True
        Else
            Gear_C1_Gear.Visible = False
            Gear_C1_LineA.Visible = False
            Gear_C1_LineB.Visible = False
        End If
    End Sub



    Private Sub Gear_L1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_L1_Check.CheckedChanged
        If Gear_L1_Check.Checked = True Then
            Gear_L1_Gear.Visible = True
            Gear_L1_LineA.Visible = True
            Gear_L1_LineB.Visible = True
        Else
            Gear_L1_Gear.Visible = False
            Gear_L1_LineA.Visible = False
            Gear_L1_LineB.Visible = False
        End If
    End Sub





    Private Sub Gear_C2_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_C2_Check.CheckedChanged
        If Gear_C2_Check.Checked = True Then
            Gear_C2_Gear.Visible = True
            Gear_C2_LineA.Visible = True
            Gear_C2_LineB.Visible = True
        Else
            Gear_C2_Gear.Visible = False
            Gear_C2_LineA.Visible = False
            Gear_C2_LineB.Visible = False
        End If
    End Sub



    Private Sub Gear_L2_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_L2_Check.CheckedChanged
        If Gear_L2_Check.Checked = True Then
            Gear_L2_Gear.Visible = True
            Gear_L2_LineA.Visible = True
            Gear_L2_LineB.Visible = True
        Else
            Gear_L2_Gear.Visible = False
            Gear_L2_LineA.Visible = False
            Gear_L2_LineB.Visible = False
        End If
    End Sub

    Private Sub Gear_D1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_D1_Check.CheckedChanged
        If Gear_D1_Check.Checked = True Then
            Gear_D1_Gear.Visible = True
            Gear_D1_LineA.Visible = True
            Gear_D1_LineB.Visible = True
        Else
            Gear_D1_Gear.Visible = False
            Gear_D1_LineA.Visible = False
            Gear_D1_LineB.Visible = False
        End If
    End Sub


    Private Sub Gear_M1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_M1_Check.CheckedChanged
        If Gear_M1_Check.Checked = True Then
            Gear_M1_Gear.Visible = True
            Gear_M1_LineA.Visible = True
            Gear_M1_LineB.Visible = True
        Else
            Gear_M1_Gear.Visible = False
            Gear_M1_LineA.Visible = False
            Gear_M1_LineB.Visible = False
        End If
    End Sub




    Private Sub MainPlate_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainPlate_Check.CheckedChanged
        If MainPlate_Check.Checked = True Then
            MainPlate.Visible = True
        Else
            MainPlate.Visible = False
        End If
    End Sub





    Private Sub Gear_D2_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_D2_Check.CheckedChanged
        If Gear_D2_Check.Checked = True Then
            Gear_D2_Gear.Visible = True
            Gear_D2_LineA.Visible = True
            Gear_D2_LineB.Visible = True
        Else
            Gear_D2_Gear.Visible = False
            Gear_D2_LineA.Visible = False
            Gear_D2_LineB.Visible = False
        End If
    End Sub


    Private Sub Gear_M2_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_M2_Check.CheckedChanged
        If Gear_M2_Check.Checked = True Then
            Gear_M2_Gear.Visible = True
            Gear_M2_LineA.Visible = True
            Gear_M2_LineB.Visible = True
        Else
            Gear_M2_Gear.Visible = False
            Gear_M2_LineA.Visible = False
            Gear_M2_LineB.Visible = False
        End If
    End Sub

    Private Sub Gear_N1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gear_N1_Check.CheckedChanged
        If Gear_N1_Check.Checked = True Then
            Gear_N1_Gear.Visible = True
            Gear_N1_LineA.Visible = True
            Gear_N1_LineB.Visible = True
        Else
            Gear_N1_Gear.Visible = False
            Gear_N1_LineA.Visible = False
            Gear_N1_LineB.Visible = False
        End If
    End Sub


    Private Sub BackPlate_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackPlate_Check.CheckedChanged
        If BackPlate_Check.Checked = True Then
            BackPlate.Visible = True
        Else
            BackPlate.Visible = False
        End If
    End Sub



    Private Sub Arm_N1_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arm_N1_Check.CheckedChanged
        If Arm_N1_Check.Checked = True Then
            Arm_N1.Visible = True
        Else
            Arm_N1.Visible = False
        End If
    End Sub


    Private Sub Plus_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Plus_Button.Click
        If Timer1.Interval > 3 Then
            Timer1.Interval = Timer1.Interval / 2
        End If
    End Sub


    Private Sub Minus_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Minus_Button.Click
        Timer1.Interval = Timer1.Interval * 2
    End Sub







End Class
