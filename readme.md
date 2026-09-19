# Sudoku Solver

This is a personal Sudoku-solving application I originally wrote in C# using Windows Forms around 2006.

I am publishing the source now as an archival example of an older personal project. It has not been modernized to current .NET or Visual Studio conventions, and the original project files target the development environment available at the time.

## What It Does

The application provides a graphical Sudoku board and attempts to solve a puzzle by applying Sudoku constraints across rows, columns, and 3x3 boxes.

The solver models the puzzle using separate objects for:

* Individual squares
* Rows, columns, and boxes
* The overall puzzle state

The solving logic reduces possible values based on existing constraints and uses recursive search when necessary.

## Project Structure

The original application was built with:

* C#
* Windows Forms
* Visual Studio 2005-era project files
* .NET Framework

The repository contains the original source with only minor cleanup for publication.

## Current Status

This project is preserved primarily as a historical example of my personal software development work.

It may require an older .NET Framework / Visual Studio environment to build and run successfully, and I have not attempted to port it to modern .NET.

## Background

I built this project independently as a way to explore Sudoku-solving logic, object modeling, recursion, event-driven UI behavior, and Windows Forms application development.

The Git history begins with the public archival import rather than the project's original development history.
