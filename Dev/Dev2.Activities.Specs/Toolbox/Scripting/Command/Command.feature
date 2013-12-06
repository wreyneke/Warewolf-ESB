﻿Feature: Command
	In order to execute command line scripts
	As a Warewolf user
	I want a tool that allows me to execute commands 

Scenario: Execute commands 
	Given I have a command variable "[[drive]]" equal to "C:\"
	#Given I have this command script to execute "@echo off"
	#And	REM Next command returns a list of programs on the given drive
	Given I have this command script to execute "dir [[drive]]Program Files"	
	When the command tool is executed
	Then the result of the command tool will be "Volume in drive C has no label"
	And command execution has "NO" error

Scenario: Execute a command that requires user interaction like pause
	Given I have this command script to execute "pause"
	When the command tool is executed
	Then the result of the command tool will be "Press any key to continue . . ."
	And command execution has "NO" error

Scenario: Execute a blank cmd
	Given I have this command script to execute ""
	When the command tool is executed
	Then the result of the command tool will be ""
	And command execution has "AN" error

Scenario: Execute invalid cmd
	Given I have this command script to execute "asdf"
	When the command tool is executed
	Then the result of the command tool will be ""
	And command execution has "AN" error

