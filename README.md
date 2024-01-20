# WindowsWellick
This project introduces a utility class, DynamicCodeHelper, designed for dynamic compilation and execution of C# code at runtime. 
The class includes methods for compiling C# code provided as a string into a dynamically linked library and subsequently executing the compiled code. 
Additionally, the code extraction from an image is accomplished using steganography techniques, enhancing security and obfuscation.

# How to Use
1. Include the DynamicCodeHelper class: Integrate the DynamicCodeHelper class into your project.

2. Compile C# Code: Call the CompileCode method, passing the C# code snippet you want to dynamically compile. This method takes care of the compilation process.

# Execution Example
```cs
Bitmap loadedImage = LoadImage(imageFilePath);
string extractedCode = ExtractText(loadedImage);
CompileCode(extractedCode);
```
# Dependencies
Microsoft.CodeAnalysis version=4.8.0
System.Drawing.Common version=8.0.1
