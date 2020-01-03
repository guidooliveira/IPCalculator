---
external help file: IPCalculator.dll-Help.xml
Module Name: IPCalculator
online version:
schema: 2.0.0
---

# New-Network

## SYNOPSIS
This command will split the subnets you wish in your VLSM Network.

## SYNTAX

```
New-Network [-NetworkSegments] <NetworkSegment[]> [-AddressSpace] <String> [<CommonParameters>]
```

## DESCRIPTION
This command will split the subnets you wish in your VLSM Network based on the list of network segments requirements you provided within the scope of the address space.

## EXAMPLES

### Example 1
```powershell
PS C:\> $List = @()
PS C:\> $List += New-NetworkSegment -Name 'Test1' -SizeNeeded 29
PS C:\> $List += New-NetworkSegment -Name 'Test2' -SizeNeeded 6
PS C:\> $List += New-NetworkSegment -Name 'Test3' -SizeNeeded 100
PS C:\> $List += New-NetworkSegment -Name 'Test4' -SizeNeeded 140
PS C:\> New-Network -NetworkSegments $List -AddressSpace '192.168.1.0/23'
```

This example will take the list of provided segments and effectively calculate the subnets within the address space.

## PARAMETERS

### -AddressSpace
Type in the Address Space in CIDR notation

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSegments
Type in the Segment Name

```yaml
Type: NetworkSegment[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.IReadOnlyCollection`1[[IPCalculator.Subnet, IPCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
