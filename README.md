# SFPdf_RTLLanguageSupport
Support right-to-left (RTL) languages (Arabic) in Syncfusion PDF package in WinRT (also can be used in uwp)

## Supported Language
- Arabic

## Known Issues
- it does not support all the fonts
- some of supported fonts it does not support the text with Tashkeel
- (long text wrapping issue)when the long line of text get wrapped, it write the lines as it is but from last to first so that the last line will be the first line in the paragraph and the first line will be the last line in the paragraph.

## How it works
- it take the arabic text word by word, each word takes its letters and draw them according to each letter position within the word.(Beginning, Middle, End, Isolated)
- each position of each letter has its own unicode character drawing.

#

#### Many thanks to Bader Alghamdi (baalghamdi) for creating ArabicScript