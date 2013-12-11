﻿Feature: Switch
	In order to branch based on the data
	As Warewolf user
	I want tool has multiple branching decisions based on the data

Scenario: Ensure that a variable evaluates to the value on the datalist
	Given I need to switch on variable "[[A]]" with the value "30"		
	When the switch tool is executed
	Then the variable "[[A]]" will evaluate to "30"
	And the switch execution has "NO" error

Scenario: Ensure that a blank variable evaluates to blank
	Given I need to switch on variable "[[A]]" with the value ""		
	When the switch tool is executed
	Then the variable "[[A]]" will evaluate to ""
	And the switch execution has "NO" error

Scenario: Ensure that a negative index throws an error
	Given I need to switch on variable "[[my(-1).var]]" with the value ""		
	When the switch tool is executed
	Then the variable "[[A]]" will evaluate to "Default"
	And the switch execution has "AN" error

