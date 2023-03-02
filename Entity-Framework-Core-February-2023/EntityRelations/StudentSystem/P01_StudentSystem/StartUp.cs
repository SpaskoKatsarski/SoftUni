namespace P01_StudentSystem;

using System;

using Data;

public class StartUp
{
    static void Main(string[] args)
    {
        StudentSystemContext context = new StudentSystemContext();
        Console.WriteLine("Connection successful!!");
    }
}