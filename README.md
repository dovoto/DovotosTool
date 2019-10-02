# DovotosTool

A 6502 interactive assembler, dissassembler, debugger, and emulator (and maybe some basics graphics editing functionality).
Current target is Nintendo Entertainment System (NES) but may expand to C64 and eventually SNES.

The primary purpose of this is reverse engineering of ROMs for static recompilation to support high speed emulation on a
low power target device.  C#/.net/GDI/winforms chosen for rapid development and easy porting and my own personal comfort
(should work fine on any mono supported platform).

The emulation portion of this project is geared primarily as an aid for the dissassembly and RE process.  It does have a
nominal speed requirement of "runs full speed on my moderately equiped desktop".  I do not intend on putting much effort in to 
making it "Fast".  There are much better emulators out there.

Current progress (this project is only about 8 hours of work old as of 10/2/19).  Overall: Not particullarly useful.

6502: fully implemented.  Very buggy.  Some cycle innacuracy for page crossing memory accesses.

NES PPU: partially implemented.  No useful output yet.  
NES APU: not started  
NES Mappers: NROM fully implemented (probably buggy)...will add mappers for interesting games  
Dissassembler: works, uggly  
Assembler: not started  
