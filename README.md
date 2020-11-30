# Unmatched Jpg Copier

This tool looks at all the files in the directory (working dir, or first parameter if provided) and copies all "abandoned" jpegs to a subdirectory named "lr-export".

## Use case

I configured my camera to save RAW+JPG for each picture. Sometimes I edit pictures in-camera, using "NEF processing" mode. This way I also "preselect" pictures on the go. When generating JPGs in camera, it creates a JPG without a matching NEF.

This program finds all JPGs without a corresponding NEF file, and places it in subdirectory.

Example invocation:

```
UnmatchedJpegCopier.exe U:\wspolne\Fotografie\2020\directory
```