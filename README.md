# StSSaveManager

`StSSaveManager` is a console application for managing Slay The Spire (StS) game save files. It allows users to encode and decode their save files using Base64 and XOR encryption, using the key `key`.

## Features

- **Encode Save Files:** Converts game save files into a Base64 encoded format with XOR encryption, which is used by the game.
- **Decode Save Files:** Decodes the Base64 encoded file with XOR encryption, to be readable and editable by a human via any common text editor.

## Requirements

- .NET Framework (or compatible runtime environment) to run the C# executable.

## Usage

The application can be used with command-line arguments to specify the action (encode or decode), input file path, and output file path.

### Encoding a Save File

    StSSaveManager.exe encode <inputFilePath> <outputFilePath>

### Decoding a Save File

    StSSaveManager.exe decode <inputFilePath> <outputFilePath>

## Contributing

Contributions are welcome. Please fork the repository and submit a pull request with your proposed changes or improvements.

## Disclaimer

This tool is created by fans and is not affiliated with the creators of Slay The Spire. Use this tool at your own risk; the authors are not responsible for any potential damage or loss of data.