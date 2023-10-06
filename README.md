# Custom Texture Tool PS
This is a PowerShell script for Windows with a GUI that makes use of the command line options of several external programs, that can perform a variety of functions for custom textures. It can be used to convert textures between PNG and DDS, and supports a wide range of DDS formats: BC1-BC7, RGBA, ARGB, L8, A8, and LA8. Other supported image formats are TIF/TIFF, TGA, and JPG for niche situations. The script automatically handles mipmaps which can be manipulated or disabled, it will auto-repair many issues found in DDS headers, and can seamlessly rescale textures and apply advanced upscaling filters.

This texture tool was designed for Dolphin emulator texture packs, so many of the core features revolve around Dolphin. Over time it has become powerful enough to manage many types of texture packs, and also convert/create "phyre" textures from The Legend of Heroes: Trails of Cold Steel series and Final Fantasy X/X2 HD remaster. The tool has a built-in help menu that covers everything it can do in detail.

NOTICE: If Microsoft, Google, Discord, or any other corporation flags my script as a "virus", I can assure you it is NOT a virus and does not do anything nefarious. All of the code is completely visible by editing the script with any standard text editor. Anyone who has the appropriate knowledge can verify that there is nothing going on that does anything that will harm your PC, steal information, etc. My only goal is to create something that people will find useful for their projects. It's really annoying these companies are trying to control the flow of software for "the greater good", when in reality it just gives them a stranglehold on who gets to create and share software.

# Installation and Setup
ImageMagick is the only hard requirement to get it up and running. The script has built-in documentation, which can be accessed by pressing the "Help" button. If you are new to using this script, I do suggest going with the "Full Installation Method" as it is the easiest to get everything up and running.

# Basic Installation Method:	
This installation method is much more advanced in the long run.<br>
It allows customizing which programs to install that CTT-PS makes use of.
- Install ImageMagick
- If creating DDS textures, install TexConv and optionally Compressonator
- Run the script by opening the CTT-PS launcher executable Custom Texture Tool PS Launcher.exe
  - You can also run the script (Custom Texture Tool PS vxx.x.ps1) by right clicking it and selecting Run with PowerShell
- Install other programs that the script requires as needed
- Link these programs to the script using the Options menu Tool Paths tab

# Full Installation Method:
This installation method is much simpler in the long run.<br>
It gives full access to all programs and features with the least amount of effort.
- Download and install the CTT-PS Programs pack - Link / Mirror
- Install ctt-ps_programs_installer.exe to default location of:
  - C:\Users\UserName\AppData\Local\CTT-PS Data\CTT-PS Programs
  - Installing to the root of any HDD (C:,D:,E:, etc) is also valid such as C:\CTT-PS Programs
  - Do NOT install to Program Files or Program Files (x86) - (Why not?)
- Run the script by opening the CTT-PS launcher executable Custom Texture Tool PS Launcher.exe
  - You can also run the script (Custom Texture Tool PS vxx.x.ps1) by right clicking it and selecting Run with PowerShell
- Click the Options button which shows the Tool Paths tab
- Check the checkbox under Tools Master Paths - Image
  - All tool paths should be automatically filled in if installed to: C:\Users\UserName\AppData\Local\CTT-PS Data\CTT-PS Programs
  - All tool paths should be automatically filled in if installed to: C:\CTT-PS Programs
- If installed somewhere else, manually locate the CTT-PS Programs folder
- Install the other included packages as needed, more info in the ReadMe.

#  Supported DDS Programs
TexConv is required to create BC7 textures, use the script's Image Viewer, and convert BC7 textures to other formats. Compressonator is capable of these tasks, but randomly fails with some images.
If confused on which program to install and use, I suggest all of them. If a program fails to create a texture, it will fall back to another one and continue to do so until the image is created. Compressonator should be selected within the tool when creating most DDS images, but TexConv is still required for when Compressonator fails to create an image.
- **ImageMagick**: Default. Can create DXT1, DXT5, and ARGB8. Creates very low quality DXT1/DXT5 DDS textures. Uses magick.exe.
- **DirectX TexConv**: Can create DXT1, DXT5, BC7, and ARGB8. Lower quality DXT1/DXT5 textures, high quality BC7 textures. Uses texconv.exe.
- **Compressonator**: Can create DXT1, DXT5, BC7, and ARGB8. Highest quality BC7 textures. Fails creating some textures. Uses CompressonatorCLI.exe.

# Other Supported Programs

The following programs are used to apply an upscaling filter to textures.
- **xBRZ ScalerTest:** Allows upscaling textures with the xBRZ filter.
- **Waifu2x-Caffe:** Allows upscaling textures with waifu2x filter (nvidia cards required for full speed).
- **Waifu2x-CPP:** Not as powerful as waifu2x-caffe, but supports OpenCL (faster than using CPU for AMD users).
- **ESRGAN:** Enhanced Super-Resolution Generative Adversarial Networks.
- **SFTGAN:** Recovering Realistic Texture in Image Super-resolution by Deep Spatial Feature Transform.
- **Python v3.9.x:** Multi-platform scripting language. Required to use ESRGAN and SFTGAN upscaling filters. Only v3.9.x is supported at the moment.

The following programs can be used to optimize PNG textures.
- **OptiPNG**: Attempts to reduce the file size of PNG images.
- **OxiPNG**: An alternative to OptiPNG that supports multi-threading for better performance.
- **Pingo**: From my personal testing, this one seems to yield the best compression for PNG images.
- **ECT**: Supports a number of image formats, but only used for PNG in CTT-PS.

The following programs are used to create materials for Ishiiruka Dolphin.
- **Ishiiruka Tool**: Required to work with material map textures, and create them from materials.
- **Material Map Generator**: Generates materials from color textures that can be combined with Ishiiruka Tool.

The following programs can be used to unpack PKG files for The Legend of Heroes: Trails of Cold Steel I and II.
- **Kiseki PKG Sharp**: This is the best PKG tool which supports recompressing PKG files.
- **PKGTool**: An alternate PKG tool, this one is only mentioned if having issues with the one above.

None of these programs are required to use the script, but they are needed to unlock the features they support.

# Features

- Generate Dolphin Resource Packs.
- Supports PNG, DDS, JPG, TIF/TIFF, and TGA image formats.
- Rescale all textures at a fixed integer scale.
- DDS can be created with DXT1, DXT5, BC7, or uncompressed ARGB8.
- Check textures for a variety of issues (scaling factors, aspect ratios, etc.).
- Copy textures identified with issues to a folder for manual fixing.
- Auto-repair most textures that are identified with issues.
- Missing mipmaps are automatically generated when repairing/converting.
- Custom mipmaps can be provided or the script can be forced to generate new ones.
- The type of DDS mipmaps generated (internal/external) can be configured.
- Create material maps from color, bump, spec, nrm, and lum textures (required Ishiiruka Tool).
- Rescale/Convert already combined material maps (the generated nrm texture).
- Existing material maps and/or materials are automatically handled when found.
- Optimize PNG file sizes using OptiPNG. Can be written "in-place" or optionally output files to a folder.
- Apply various upscaling filters to all textures including xBRZ and Waifu2x.
- And much much more! Refer to the built-in "Help" button for more information.

# CTT-PS Useful Links

Compression Flags: Creating DDS textures with multiple compression types in a single run.
PNG Alpha Manipulation: Weird Alpha in PNG Textures - and an option to manipulate it!
Texture Watermarks: Names overlaying textures to identify their location in-game.
Material Textures: Creating materials that can be turned into material maps.
Material Maps: Creating material map textures for Dolphin Ishiiruka.
Combine/Split Images: Combining multiple images into a single image, or splitting an image.
OptiPNG/OxiPNG: Why it should only be used with this script for Dolphin textures.
Process Selected: The super secret option that nobody knows about.
Phyre Textures: Working with textures from The Legend of Heroes: Trails of Cold Steel I and II.
BC7 DDS Format: The beginning and my initial failure.
• Part 1: I know almost nothing.
• Part 2: Custom mipmaps for BC7!
• Part 3: BC7 becomes a reality.
Metroid Font Textures: Retexture thousands of fonts in minutes!
Custom CLI Programs: Import any program that accepts command line input into CTT-PS.
Split/Combine Color Channels: Split images into several images based on the RGBA channels, then put them back together.
