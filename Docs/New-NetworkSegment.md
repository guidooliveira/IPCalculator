---
external help file: IPCalculator.dll-Help.xml
Module Name: IPCalculator
online version:
schema: 2.0.0
---

# New-NetworkSegment

## SYNOPSIS
This command will define the Segment or Segments you wish in your VLSM Network

## SYNTAX

```
New-NetworkSegment [-Name] <String> [-SizeNeeded] <Int32> [<CommonParameters>]
```

## DESCRIPTION
This command will define the Segment or Segments you wish in your VLSM Network

## EXAMPLES

### Example 1
```powershell
PS C:\> $Segment = New-NetworkSegment -Name 'Test1' -SizeNeeded 29
```

In this example we are using a single segment

### Example 2
```powershell
PS C:\> $List = @()
PS C:\> $List += New-NetworkSegment -Name 'Test1' -SizeNeeded 29
PS C:\> $List += New-NetworkSegment -Name 'Test2' -SizeNeeded 6
PS C:\> $List += New-NetworkSegment -Name 'Test3' -SizeNeeded 100
PS C:\> $List += New-NetworkSegment -Name 'Test4' -SizeNeeded 140
```

In this example we are using a list of segment

## PARAMETERS

### -Name
Type in the Segment Name

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SizeNeeded
Type in the Amount of hosts needed in the segment

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.IReadOnlyCollection`1[[IPCalculator.NetworkSegment, IPCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
