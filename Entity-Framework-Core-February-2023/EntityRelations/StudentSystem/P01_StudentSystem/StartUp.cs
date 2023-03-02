namespace P01_StudentSystem;

using System;

using Data;

public class StartUp
{
    static void Main(string[] args)
    {
        //TODO: Get rid of the magic numbers and move them to DbConfig from Common

        StudentSystemContext context = new StudentSystemContext();
        Console.WriteLine("Connection successful!!");
    }
}