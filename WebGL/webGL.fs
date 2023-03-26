\ *********************************************************************
\ WebGL / OpenGL definitions for eFORTH
\    Filename:      webGL.fs
\    Date:          26 mar 2023
\    Updated:       26 mar 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************




\ documentation about OpenGL: http://www.opengl-tutorial.org/fr/


vocabulary WebGL
WebGL definitions
web
 
JSWORD: window { w h }
  const canvas = document.createElement('canvas');
  context.canvas.width = w;
  context.canvas.height = h;
  context.canvas.style.width = w+'px';
  context.canvas.style.height = h+'px';
  // context.canvas.style.top = 0;
   // context.canvas.style.left = 0;
   // context.canvas.style.position = 'fixed';
  context.ctx = canvas.getContext('webgl');
  if (!context.ctx) {
    alert("Impossible d'initialiser WebGL. Votre navigateur ou votre machine peut ne pas le supporter.");
  }
~
 
\ JSWORD: grmode { mode } 
\   context.setMode(mode); 
\ ~ 
\ : gr   1 grmode ; 
\ : text   0 grmode ;   

\ forth definitions

