Module Module1

    'This program takes in 4 candidates and makes a vote type thing   :)

    Dim NumVoters, votes(3) As Integer
    Dim CandidateName(3) As String
    Dim tieBetween(3) As Integer

    Sub main()


        Console.WriteLine("How many voters are there? ")
        NumVoters = Console.ReadLine

        Console.Clear()
        NameInput()

        For index = 0 To 3
            votes(index) = 0
        Next

        For x = 1 To NumVoters

            Console.Clear()
            Console.WriteLine("The candidates are: ")
            voting(x)

        Next
        Console.Clear()
        decisionMaking()




        For x = 0 To 4
            Console.WriteLine("")
        Next
    End Sub


    Sub decisionMaking()
        Dim highestIndex As Integer
        For index = 0 To 3
            tieBetween(index) = 9999
        Next

        Dim tie As Boolean = CheckingDouble()


        If tie = True Then
            Console.WriteLine("There is a tie between : ")
            For index = 0 To 3
                If tieBetween(index) <> 9999 Then
                    Console.WriteLine(CandidateName(tieBetween(index) - 1))
                End If
            Next
        Else
            highestIndex = highestVote()
            Console.WriteLine("The highest vote goes to: " & CandidateName(highestIndex))
        End If


    End Sub


    Function highestVote() As Integer
        Dim highestIndex As Integer = 0


        For index = 0 To 3
            If votes(index) > votes(highestIndex) Then
                highestIndex = index
            End If
        Next
        Return highestIndex
    End Function

    Function CheckingDouble() As Boolean
        Dim tie As Boolean = False
        Dim maxVoteIndex As Integer = highestVote()

        For index = 0 To 3


            For index2 = 0 To 3
                If index <> index2 Then
                    If votes(index) = votes(index2) And votes(index) <> 0 And votes(index) >= votes(maxVoteIndex) Then
                        tie = True
                        For tieIndex = 0 To 3
                            If tieBetween(tieIndex) = 9999 Then
                                tieBetween(tieIndex) = index + 1
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        Next


        Return tie
    End Function

    Sub voting(ByVal voteNumber As Integer)
        Dim voteFor As Integer
        Dim voteSuccessfull As Boolean

        Do
            PrintNames()

            Console.WriteLine("Enter the respective number of the person you want to vote for: ")
            Console.Write("Vote Number {0}:  ", voteNumber)

            voteSuccessfull = True

            voteFor = Console.ReadLine

            Select Case voteFor
                Case 1
                    votes(0) = votes(0) + 1
                Case 2
                    votes(1) = votes(1) + 1
                Case 3
                    votes(2) = votes(2) + 1
                Case 4
                    votes(3) = votes(3) + 1
                Case Else
                    voteSuccessfull = False
                    Console.Clear()
                    Console.WriteLine("You entered a wrong number, Try again: ")
            End Select
        Loop Until voteSuccessfull = True

    End Sub

    Sub PrintNames()
        For x = 1 To 4
            Console.WriteLine("         {0}. {1}", x, CandidateName(x - 1))
        Next
    End Sub

    Sub NameInput()
        Console.WriteLine("Enter the names of the candidate: ")
        For x = 0 To 3
            Console.Write(x + 1 & ". ")
            CandidateName(x) = Console.ReadLine()
        Next
    End Sub
End Module
