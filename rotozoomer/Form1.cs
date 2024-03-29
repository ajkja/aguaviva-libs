﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rotozoomer
{
   public partial class Form1 : Form
   {
      short time = 0;
      byte aa = 0;
      short z = 256;
      short zz = 1;
      sbyte[] sin_lut = new sbyte[256];

      byte mode = 0;
      byte effect = 3;
      byte limits = 0;

      /*
      sbyte[] sin_lut = new sbyte[] {
         0x00,0x03,0x06,0x09,0x0c,0x0f,0x12,0x15,0x19,0x1c,0x1f,0x22,0x25,0x28,0x2b,0x2e,
         0x31,0x34,0x36,0x39,0x3c,0x3f,0x42,0x44,0x47,0x49,0x4c,0x4f,0x51,0x53,0x56,0x58,
         0x5a,0x5c,0x5f,0x61,0x63,0x65,0x67,0x68,0x6a,0x6c,0x6e,0x6f,0x71,0x72,0x73,0x75,
         0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7d,0x7e,0x7e,0x7f,0x7f,0x7f,0x7f,0x7f,
         0x7f,0x7f,0x7f,0x7f,0x7f,0x7e,0x7e,0x7d,0x7d,0x7c,0x7b,0x7b,0x7a,0x79,0x78,0x77,
         0x75,0x74,0x73,0x71,0x70,0x6e,0x6d,0x6b,0x69,0x68,0x66,0x64,0x62,0x60,0x5e,0x5b,
         0x59,0x57,0x55,0x52,0x50,0x4d,0x4b,0x48,0x46,0x43,0x40,0x3d,0x3b,0x38,0x35,0x32,
         0x2f,0x2c,0x29,0x26,0x23,0x20,0x1d,0x1a,0x17,0x14,0x11,0x0e,0x0b,0x07,0x04,0x01,
         0xff,0xfc,0xf9,0xf5,0xf2,0xef,0xec,0xe9,0xe6,0xe3,0xe0,0xdd,0xda,0xd7,0xd4,0xd1,
         0xce,0xcb,0xc8,0xc5,0xc3,0xc0,0xbd,0xba,0xb8,0xb5,0xb3,0xb0,0xae,0xab,0xa9,0xa7,
         0xa5,0xa2,0xa0,0x9e,0x9c,0x9a,0x98,0x97,0x95,0x93,0x92,0x90,0x8f,0x8d,0x8c,0x8b,
         0x89,0x88,0x87,0x86,0x85,0x85,0x84,0x83,0x83,0x82,0x82,0x81,0x81,0x81,0x81,0x81,
         0x81,0x81,0x81,0x81,0x81,0x82,0x82,0x83,0x83,0x84,0x85,0x86,0x87,0x88,0x89,0x8a,
         0x8b,0x8d,0x8e,0x8f,0x91,0x92,0x94,0x96,0x98,0x99,0x9b,0x9d,0x9f,0xa1,0xa4,0xa6,
         0xa8,0xaa,0xad,0xaf,0xb1,0xb4,0xb7,0xb9,0xbc,0xbe,0xc1,0xc4,0xc7,0xca,0xcc,0xcf,
         0xd2,0xd5,0xd8,0xdb,0xde,0xe1,0xe4,0xe7,0xeb,0xee,0xf1,0xf4,0xf7,0xfa,0xfd 
      };
      */

      byte[] m_pic = new byte[] {
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1F, 0xEF, 0xEF, 
         0xEF, 0xFF, 0x1F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 
         0x1F, 0xEF, 0xEF, 0x01, 0xFF, 0xFF, 0x0B, 0xFF, 
         0xFF, 0x0F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 0x1F, 
         0xEF, 0xEF, 0x0F, 0xFF, 0xFF, 0x01, 0xFF, 0xFF, 
         0x3F, 0xAF, 0xAF, 0x1F, 0xFF, 0xFF, 0x01, 0xEF, 
         0xEF, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 
         0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 0x01, 0xFF, 0xFF, 
         0x1F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 0x1F, 0xEF, 
         0xEF, 0x0F, 0xFF, 0xFF, 0xDF, 0xAF, 0x2F, 0xFF, 
         0xFF, 0x0F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 0x1F, 
         0xEF, 0xEF, 0x1F, 0xFF, 0xEF, 0x07, 0xEF, 0xEF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0x1F, 0xEF, 0xEF, 0xEF, 
         0xFF, 0x1F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 0x0F, 
         0xEF, 0xEF, 0x1F, 0xEF, 0xEF, 0x1F, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 
         0xFE, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 
         0xFF, 0xFE, 0x3F, 0x7F, 0xFE, 0xFF, 0xFF, 0xFF, 
         0xFA, 0xFA, 0xFC, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 
         0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFE, 0xFE, 
         0xFE, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFE, 
         0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 
         0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFA, 
         0xFA, 0xFC, 0xFF, 0xFF, 0xFE, 0xFE, 0xFE, 0xFF, 
         0xFF, 0xF8, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0x7E, 
         0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFE, 
         0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFE, 
         0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0x1F, 0x00, 0x78, 0xE0, 0xC1, 0x83, 0x4F, 
         0x1F, 0x3F, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0x7F, 0x3F, 0x9F, 0x07, 0x83, 0xC1, 0xF0, 0x00, 
         0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0x80, 0x70, 0xF8, 0x18, 0x34, 0x6C, 0x6C, 
         0x3C, 0x6C, 0x6C, 0xB5, 0x7B, 0x87, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0x7F, 0x3F, 0x9F, 0x5F, 0x8F, 0x8F, 0x2F, 
         0x0F, 0x87, 0x47, 0xA7, 0x07, 0x47, 0x07, 0x07, 
         0x87, 0x8F, 0xEF, 0xEF, 0xEF, 0x5F, 0x1F, 0x3F, 
         0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0xF7, 0x6B, 0xD8, 
         0xD8, 0x78, 0xD8, 0xD9, 0x69, 0x31, 0xF0, 0xE0, 
         0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0x03, 
         0x01, 0x00, 0x70, 0x80, 0x0F, 0x10, 0x3C, 0x40, 
         0xF0, 0x00, 0xF0, 0x0F, 0xE1, 0x01, 0x07, 0xCF, 
         0xDF, 0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFC, 0x78, 0x00, 0x02, 0x04, 0x32, 0x72, 
         0x84, 0x0A, 0x02, 0x0D, 0x06, 0x0D, 0x06, 0x0B, 
         0x04, 0x07, 0x07, 0x07, 0x00, 0x01, 0x02, 0x78, 
         0xFC, 0xFD, 0xFB, 0x07, 0xFF, 0xFF, 0xFF, 0xFF, 
         0x7F, 0xBF, 0x9F, 0x0F, 0x03, 0xC2, 0x1F, 0xE0, 
         0x00, 0xE0, 0x80, 0x78, 0x20, 0x1E, 0x01, 0xE0, 
         0x01, 0x03, 0x07, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFC, 0xC0, 
         0x00, 0x1C, 0xFF, 0x3E, 0x01, 0x3E, 0x20, 0x20, 
         0x20, 0xA1, 0x20, 0x30, 0x3F, 0xF8, 0xE0, 0x8F, 
         0x7F, 0x80, 0xFF, 0xFF, 0xFF, 0xFF, 0x1F, 0x07, 
         0x01, 0x00, 0xF8, 0xFC, 0xFE, 0x0E, 0x00, 0x00, 
         0x00, 0x01, 0x02, 0x04, 0x04, 0x08, 0x08, 0x08, 
         0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x08, 
         0x08, 0x05, 0x04, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 
         0x00, 0xFF, 0x1F, 0xC0, 0xF0, 0x7F, 0x60, 0x41, 
         0x42, 0x41, 0x40, 0x40, 0x7C, 0x02, 0x7D, 0xFE, 
         0x38, 0x00, 0x80, 0xF8, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0x9E, 0x1D, 0x28, 0x24, 0x68, 0x78, 0xF0, 
         0xF0, 0x3F, 0x28, 0x28, 0x30, 0x79, 0x7F, 0x7F, 
         0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7E, 0x18, 
         0x30, 0x20, 0x60, 0x43, 0xC7, 0xCF, 0x8E, 0x8C, 
         0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 
         0x80, 0x80, 0x00, 0x80, 0x40, 0xC0, 0x40, 0x60, 
         0xE0, 0x90, 0x88, 0x0E, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFC, 0xFF, 0xFF, 0xF3, 0x60, 0x50, 0x50, 
         0x7F, 0xE0, 0xE0, 0xF0, 0xD0, 0x48, 0x50, 0x3B, 
         0x3C, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFC, 0xFC, 0xFC, 
         0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFC, 0xFC, 0xFC, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFC, 
         0xFC, 0xFC, 0xFE, 0xCF, 0xC3, 0xC5, 0xC6, 0xCF, 
         0xF0, 0xFD, 0xFB, 0xE3, 0xC2, 0xC5, 0xC2, 0xFD, 
         0xFB, 0xF3, 0xE1, 0xE0, 0xE1, 0xF2, 0xFD, 0xF8, 
         0xF8, 0xF0, 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xF8, 0xF8, 0xF8, 0xFC, 0xFC, 0xFE, 
         0xFE, 0xFF, 0xF9, 0xF8, 0xF8, 0xFC, 0xFC, 0xFE, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
      };

      byte[] font5x8 = new byte[] 
      {
         0x00, 0x00, 0x00, 0x00, 0x00, // (spacja)
         0x00, 0x00, 0x5F, 0x00, 0x00, // !
         0x00, 0x07, 0x00, 0x07, 0x00, // "
         0x14, 0x7F, 0x14, 0x7F, 0x14, // #
         0x24, 0x2A, 0x7F, 0x2A, 0x12, // $
         0x23, 0x13, 0x08, 0x64, 0x62, // %
         0x36, 0x49, 0x55, 0x22, 0x50, // &
         0x00, 0x05, 0x03, 0x00, 0x00, // '
         0x00, 0x1C, 0x22, 0x41, 0x00, // (
         0x00, 0x41, 0x22, 0x1C, 0x00, // )
         0x08, 0x2A, 0x1C, 0x2A, 0x08, // *
         0x08, 0x08, 0x3E, 0x08, 0x08, // +
         0x00, 0x50, 0x30, 0x00, 0x00, // ,
         0x08, 0x08, 0x08, 0x08, 0x08, // -
         0x00, 0x30, 0x30, 0x00, 0x00, // .
         0x20, 0x10, 0x08, 0x04, 0x02, // /
         0x3E, 0x51, 0x49, 0x45, 0x3E, // 0
         0x00, 0x42, 0x7F, 0x40, 0x00, // 1
         0x42, 0x61, 0x51, 0x49, 0x46, // 2
         0x21, 0x41, 0x45, 0x4B, 0x31, // 3
         0x18, 0x14, 0x12, 0x7F, 0x10, // 4
         0x27, 0x45, 0x45, 0x45, 0x39, // 5
         0x3C, 0x4A, 0x49, 0x49, 0x30, // 6
         0x01, 0x71, 0x09, 0x05, 0x03, // 7
         0x36, 0x49, 0x49, 0x49, 0x36, // 8
         0x06, 0x49, 0x49, 0x29, 0x1E, // 9
         0x00, 0x36, 0x36, 0x00, 0x00, // :
         0x00, 0x56, 0x36, 0x00, 0x00, // ;
         0x00, 0x08, 0x14, 0x22, 0x41, // <
         0x14, 0x14, 0x14, 0x14, 0x14, // =
         0x41, 0x22, 0x14, 0x08, 0x00, // >
         0x02, 0x01, 0x51, 0x09, 0x06, // ?
         0x32, 0x49, 0x79, 0x41, 0x3E, // @
         0x7E, 0x11, 0x11, 0x11, 0x7E, // A
         0x7F, 0x49, 0x49, 0x49, 0x36, // B
         0x3E, 0x41, 0x41, 0x41, 0x22, // C
         0x7F, 0x41, 0x41, 0x22, 0x1C, // D
         0x7F, 0x49, 0x49, 0x49, 0x41, // E
         0x7F, 0x09, 0x09, 0x01, 0x01, // F
         0x3E, 0x41, 0x41, 0x51, 0x32, // G
         0x7F, 0x08, 0x08, 0x08, 0x7F, // H
         0x00, 0x41, 0x7F, 0x41, 0x00, // I
         0x20, 0x40, 0x41, 0x3F, 0x01, // J
         0x7F, 0x08, 0x14, 0x22, 0x41, // K
         0x7F, 0x40, 0x40, 0x40, 0x40, // L
         0x7F, 0x02, 0x04, 0x02, 0x7F, // M
         0x7F, 0x04, 0x08, 0x10, 0x7F, // N
         0x3E, 0x41, 0x41, 0x41, 0x3E, // O
         0x7F, 0x09, 0x09, 0x09, 0x06, // P
         0x3E, 0x41, 0x51, 0x21, 0x5E, // Q
         0x7F, 0x09, 0x19, 0x29, 0x46, // R
         0x46, 0x49, 0x49, 0x49, 0x31, // S
         0x01, 0x01, 0x7F, 0x01, 0x01, // T
         0x3F, 0x40, 0x40, 0x40, 0x3F, // U
         0x1F, 0x20, 0x40, 0x20, 0x1F, // V
         0x7F, 0x20, 0x18, 0x20, 0x7F, // W
         0x63, 0x14, 0x08, 0x14, 0x63, // X
         0x03, 0x04, 0x78, 0x04, 0x03, // Y
         0x61, 0x51, 0x49, 0x45, 0x43, // Z
         0x00, 0x00, 0x7F, 0x41, 0x41, // [
         0x02, 0x04, 0x08, 0x10, 0x20, // "\"
         0x41, 0x41, 0x7F, 0x00, 0x00, // ]
         0x04, 0x02, 0x01, 0x02, 0x04, // ^
         0x40, 0x40, 0x40, 0x40, 0x40, // _
         0x00, 0x01, 0x02, 0x04, 0x00, // `
         0x20, 0x54, 0x54, 0x54, 0x78, // a
         0x7F, 0x48, 0x44, 0x44, 0x38, // b
         0x38, 0x44, 0x44, 0x44, 0x20, // c
         0x38, 0x44, 0x44, 0x48, 0x7F, // d
         0x38, 0x54, 0x54, 0x54, 0x18, // e
         0x08, 0x7E, 0x09, 0x01, 0x02, // f
         0x08, 0x14, 0x54, 0x54, 0x3C, // g
         0x7F, 0x08, 0x04, 0x04, 0x78, // h
         0x00, 0x44, 0x7D, 0x40, 0x00, // i
         0x20, 0x40, 0x44, 0x3D, 0x00, // j
         0x00, 0x7F, 0x10, 0x28, 0x44, // k
         0x00, 0x41, 0x7F, 0x40, 0x00, // l
         0x7C, 0x04, 0x18, 0x04, 0x78, // m
         0x7C, 0x08, 0x04, 0x04, 0x78, // n
         0x38, 0x44, 0x44, 0x44, 0x38, // o
         0x7C, 0x14, 0x14, 0x14, 0x08, // p
         0x08, 0x14, 0x14, 0x18, 0x7C, // q
         0x7C, 0x08, 0x04, 0x04, 0x08, // r
         0x48, 0x54, 0x54, 0x54, 0x20, // s
         0x04, 0x3F, 0x44, 0x40, 0x20, // t
         0x3C, 0x40, 0x40, 0x20, 0x7C, // u
         0x1C, 0x20, 0x40, 0x20, 0x1C, // v
         0x3C, 0x40, 0x30, 0x40, 0x3C, // w
         0x44, 0x28, 0x10, 0x28, 0x44, // x
         0x0C, 0x50, 0x50, 0x50, 0x3C, // y
         0x44, 0x64, 0x54, 0x4C, 0x44, // z
         0x00, 0x08, 0x36, 0x41, 0x00, // {
         0x00, 0x00, 0x7F, 0x00, 0x00, // |
         0x00, 0x41, 0x36, 0x08, 0x00, // }
         0x08, 0x08, 0x2A, 0x1C, 0x08, // ->
         0x08, 0x1C, 0x2A, 0x08, 0x08  // <-
      };

      byte[] konami_font = new byte[]
      {
         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x00, 0xBE, 0xBE, 0x0E, 0x00, 0x00, 
         0x00, 0x00, 0x0E, 0x06, 0x00, 0x0E, 0x06, 0x00, 
         0x00, 0x28, 0xFE, 0xFE, 0x28, 0xFE, 0xFE, 0x28, 
         0x00, 0x08, 0x5C, 0x54, 0xFE, 0x54, 0x74, 0x20, 
         0x00, 0x84, 0x4A, 0x24, 0x10, 0x48, 0xA4, 0x42, 
         0x00, 0x60, 0x9C, 0x9A, 0xB2, 0xEC, 0x40, 0xA0, 
         0x00, 0x00, 0x16, 0x0E, 0x00, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x38, 0x7C, 0xC6, 0x82, 0x00, 0x00, 
         0x00, 0x00, 0x00, 0x82, 0xC6, 0x7C, 0x38, 0x00, 
         0x00, 0x00, 0x44, 0x28, 0x10, 0x28, 0x44, 0x00, 
         0x00, 0x00, 0x10, 0x10, 0x7C, 0x10, 0x10, 0x00, 
         0x00, 0x00, 0x80, 0xE0, 0x60, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x10, 0x10, 0x10, 0x10, 0x10, 0x00, 
         0x00, 0x00, 0x00, 0xC0, 0xC0, 0x00, 0x00, 0x00, 
         0x00, 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 
         0x00, 0x38, 0x7C, 0xC2, 0x82, 0x86, 0x7C, 0x38, 
         0x00, 0x00, 0x80, 0x84, 0xFE, 0xFE, 0x80, 0x80, 
         0x00, 0xC4, 0xE6, 0xF2, 0xB2, 0xBA, 0x9E, 0x8C, 
         0x00, 0x40, 0xC2, 0x92, 0x9A, 0x9E, 0xF6, 0x62, 
         0x00, 0x30, 0x38, 0x2C, 0x26, 0xFE, 0xFE, 0x20, 
         0x00, 0x4E, 0xCE, 0x8A, 0x8A, 0x8A, 0xFA, 0x70, 
         0x00, 0x78, 0xFC, 0x96, 0x92, 0x92, 0xF2, 0x60, 
         0x00, 0x06, 0x06, 0xE2, 0xF2, 0x1A, 0x0E, 0x06, 
         0x00, 0x6C, 0x9E, 0x9A, 0xB2, 0xB2, 0xEC, 0x60, 
         0x00, 0x0C, 0x9E, 0x92, 0x92, 0xD2, 0x7E, 0x3C, 
         0x00, 0x00, 0x00, 0x6C, 0x6C, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x80, 0xEC, 0x6C, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x10, 0x38, 0x6C, 0xC6, 0x82, 0x00, 
         0x00, 0x00, 0x28, 0x28, 0x28, 0x28, 0x28, 0x00, 
         0x00, 0x00, 0x82, 0xC6, 0x6C, 0x38, 0x10, 0x00, 
         0x00, 0x0C, 0x0E, 0xA6, 0xA6, 0xB6, 0x1E, 0x0C, 
         0x00, 0x38, 0x7C, 0xC6, 0x82, 0x9A, 0xDE, 0x5C, 
         0x00, 0xF8, 0xFC, 0x26, 0x22, 0x26, 0xFC, 0xF8, 
         0x00, 0xFE, 0xFE, 0x92, 0x92, 0x92, 0xFE, 0x6C, 
         0x00, 0x38, 0x7C, 0xC6, 0x82, 0x82, 0xC6, 0x44, 
         0x00, 0xFE, 0xFE, 0x82, 0x82, 0xC6, 0x7C, 0x38, 
         0x00, 0xFE, 0xFE, 0x92, 0x92, 0x92, 0x92, 0x82, 
         0x00, 0xFE, 0xFE, 0x12, 0x12, 0x12, 0x12, 0x02, 
         0x00, 0x38, 0x7C, 0xC6, 0x82, 0x92, 0xF2, 0xF2, 
         0x00, 0xFE, 0xFE, 0x10, 0x10, 0x10, 0xFE, 0xFE, 
         0x00, 0x00, 0x82, 0x82, 0xFE, 0xFE, 0x82, 0x82, 
         0x00, 0x40, 0xC0, 0x80, 0x80, 0x80, 0xFE, 0x7E, 
         0x00, 0xFE, 0xFE, 0x30, 0x78, 0xEC, 0xC6, 0x82, 
         0x00, 0xFE, 0xFE, 0x80, 0x80, 0x80, 0x80, 0x80, 
         0x00, 0xFE, 0xFE, 0x1C, 0x38, 0x1C, 0xFE, 0xFE, 
         0x00, 0xFE, 0xFE, 0x1C, 0x38, 0x70, 0xFE, 0xFE, 
         0x00, 0x7C, 0xFE, 0x82, 0x82, 0x82, 0xFE, 0x7C, 
         0x00, 0xFE, 0xFE, 0x22, 0x22, 0x22, 0x3E, 0x1C, 
         0x00, 0x7C, 0xFE, 0x82, 0xA2, 0xE2, 0x7E, 0xBC, 
         0x00, 0xFE, 0xFE, 0x22, 0x62, 0xF2, 0xDE, 0x9C, 
         0x00, 0x4C, 0xDE, 0x92, 0x92, 0x96, 0xF4, 0x60, 
         0x00, 0x00, 0x02, 0x02, 0xFE, 0xFE, 0x02, 0x02, 
         0x00, 0x7E, 0xFE, 0x80, 0x80, 0x80, 0xFE, 0x7E, 
         0x00, 0x1E, 0x3E, 0x70, 0xE0, 0x70, 0x3E, 0x1E, 
         0x00, 0xFE, 0xFE, 0x70, 0x38, 0x70, 0xFE, 0xFE, 
         0x00, 0xC6, 0xEE, 0x7C, 0x38, 0x7C, 0xEE, 0xC6, 
         0x00, 0x00, 0x0E, 0x1E, 0xF0, 0xF0, 0x1E, 0x0E, 
         0x00, 0xC2, 0xE2, 0xF2, 0xBA, 0x9E, 0x8E, 0x86, 
         0x00, 0x00, 0x00, 0xFE, 0xFE, 0x82, 0x82, 0x00, 
         0x00, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 
         0x00, 0x00, 0x82, 0x82, 0xFE, 0xFE, 0x00, 0x00, 
         0x00, 0x00, 0x18, 0x0C, 0x06, 0x0C, 0x18, 0x00, 
         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x00, 0x00, 0x06, 0x0C, 0x18, 0x00, 
         0xFC, 0x42, 0x89, 0x41, 0x81, 0x49, 0x82, 0x7C, 
         0x00, 0x00, 0x1E, 0x20, 0x40, 0x46, 0x48, 0x48, 
         0x48, 0x48, 0x46, 0x40, 0x20, 0x1E, 0x00, 0x00, 
         0x00, 0x00, 0x00, 0xF0, 0x08, 0x04, 0xC4, 0x24, 
         0x24, 0x24, 0x24, 0xC4, 0x04, 0x08, 0xF0, 0x00, 
         0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 
         0x00, 0x00, 0xFE, 0x00, 0x00, 0xFE, 0x00, 0x00, 
         0x3C, 0x42, 0x95, 0xA1, 0xA1, 0x95, 0x42, 0x3C, 
         0x00, 0x00, 0x82, 0x82, 0xFE, 0xFE, 0x82, 0x82, 
         0x00, 0x40, 0xC0, 0x80, 0x80, 0x80, 0xFE, 0x7E, 
         0x00, 0xFE, 0xFE, 0x30, 0x78, 0xEC, 0xC6, 0x82, 
         0x00, 0xFE, 0xFE, 0x80, 0x80, 0x80, 0x80, 0x80, 
         0x00, 0xFE, 0xFE, 0x1C, 0x38, 0x1C, 0xFE, 0xFE, 
         0x00, 0xFE, 0xFE, 0x1C, 0x38, 0x70, 0xFE, 0xFE, 
         0x00, 0x7C, 0xFE, 0x82, 0x82, 0x82, 0xFE, 0x7C, 
         0x00, 0xFE, 0xFE, 0x22, 0x22, 0x22, 0x3E, 0x1C, 
         0x00, 0x7C, 0xFE, 0x82, 0xA2, 0xE2, 0x7E, 0xBC, 
         0x00, 0xFE, 0xFE, 0x22, 0x62, 0xF2, 0xDE, 0x9C, 
         0x00, 0x4C, 0xDE, 0x92, 0x92, 0x96, 0xF4, 0x60, 
         0x00, 0x00, 0x02, 0x02, 0xFE, 0xFE, 0x02, 0x02, 
         0x00, 0x7E, 0xFE, 0x80, 0x80, 0x80, 0xFE, 0x7E, 
         0x00, 0x1E, 0x3E, 0x70, 0xE0, 0x70, 0x3E, 0x1E, 
         0x00, 0xFE, 0xFE, 0x70, 0x38, 0x70, 0xFE, 0xFE, 
         0x00, 0xC6, 0xEE, 0x7C, 0x38, 0x7C, 0xEE, 0xC6, 
         0x00, 0x00, 0x0E, 0x1E, 0xF0, 0xF0, 0x1E, 0x0E, 
         0x00, 0xC2, 0xE2, 0xF2, 0xBA, 0x9E, 0x8E, 0x86, 
         0x00, 0x00, 0x10, 0xFE, 0xFE, 0x82, 0x82, 0x00, 
         0x00, 0x00, 0x00, 0xFE, 0xFE, 0x00, 0x00, 0x00, 
         0x00, 0x00, 0x82, 0x82, 0xFE, 0xFE, 0x10, 0x00, 
         0x00, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00, 0x00, 
         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 
      };

      public Form1()
      {
         InitializeComponent();


         for (byte i = 0; i < 255; i++)
         {
            sin_lut[i] = (sbyte)(128 * Math.Sin(i * 2 * 3.1415 / 255));
            /*
            textBox1.Text += string.Format("0x{0:00},", ((sbyte)sin_lut[i]).ToString("x"));
            if ( (i+1 & 0xf) == 0 )
               textBox1.Text += string.Format("\r\n");
             */
         }
      }

      void Plot(Graphics g, byte x, byte y, byte col)
      {

         Brush br = Brushes.Black;
         if ( col > 0)
            br = Brushes.White;

         if ( x<128 && y<64 )
            g.FillRectangle(br, x * 2, y * 2, 1 * 2, 1 * 2);
      }

      byte y8 = 1;

      // returns values from 1 to 255 inclusive, period is 255
      byte xorshift8() 
      {
          y8 ^= (byte)(y8 << 7);
          y8 ^= (byte)(y8 >> 5);
          return y8 ^= (byte)(y8 << 3);
      }


      byte num_stars = 32;
      byte starfieldz=1;
      sbyte multi = 32;
      sbyte dist = 32;
      private void Starfield(Graphics g)
      {
         y8 = 1;
         for (byte i = 0; i < 255; i++)
         {
            sbyte x = (sbyte)xorshift8();
            sbyte y = (sbyte)xorshift8();
            sbyte z = (sbyte)(i >> 1);// (sbyte)(((starfieldz + i >> 1)) & 127);

            y+= (sbyte)(((starfieldz + i))&255);

            if ( z>23)
               Plot(g, (byte)((multi*x / z)+64), (byte)(((multi/2)*y / z)+32), (byte)1);

         }
         starfieldz--;

      }

      private byte ScrollText(char x, char y, int time)
      {
         string str2 = "ESTE ES UN SEGUNDO SCROLLER MAS LOCO QUE EL PRIMEROOOO A QUE MOLA EH???? WOHOOOO!!!! BUENOO Y YSA NO SE QUE MAS DECIR PERO ESEPRO QUE TE GUSTEEE"; 
         //string str = "HOLA QUE TAL ESTAS COMOME GUSTA MERENDAR 1, 2, 3, 4, 5, 6, 7, 8, 9, 0............... ";
         string str = "qwertyuiopasdfghjklzxcvbnm, qwertyuiopasdfghjklzxcvbnmklzxcvbnm, qwertyuiopasdfghjklzxcvbnmklzxcvbnm, qwertyuiopasdfghjklzxcvbnmklzxcvbnm, qwertyuiopasdfghjklzxcvbnm";
         
         if ( y<32-5 || y>32+4+8 )
            return 0;
         //return 1;
         if (y < 32 + 4)
         {

            int cc = (x + time);

            char c = str[(cc >> 3) & 127];
            if (c == ' ')
               return 0;

            return ((konami_font[((c - ' ') << 3) + (cc&7)] & (byte)(1 << (y - 24) - 3)) == 0) ? (byte)0 : (byte)1;
         }
         else
         {
            int cc = (x + time * 2 );

            char c = str2[ (cc >> 3) & 127];
            if (c == ' ')
               return 0;

            return ((konami_font[((c - ' ') << 3) + (cc&7)] & (byte)(1 << (y - 24) - 3-8)) == 0) ? (byte)0 : (byte)1;
         }

      }

      private void Roto(Graphics g, byte [] pic)
      {
         short _sin = (short)(sin_lut[aa]);
         short _cos = (short)(sin_lut[(aa + 64) & 255]);

         _sin = (short)(_sin * z / 256);
         _cos = (short)(_cos * z / 256);

         short x1 = (short)(-64 * _cos - (32 - limits) * _sin);
         short y1 = (short)(+64 * _sin - (32 - limits) * _cos);

         //y1 += (short)(8 * sin_lut[(time & 255)]);

         char xx, yy;

         for (byte y = limits; y < 64 - limits; y++)
         {
            short x2 = x1;
            short y2 = y1;

            for (byte x = 0; x < 128; x++)
            {
               if ( mode == 0 )
               {
                  xx = (char)(((x2 >> 7) + 64) & 127);
                  yy = (char)(((y2 >> 7) + 32) & 63);
               }
               else
               {
                  xx = (char)(((((x2 + sin_lut[(y * 4 + time) & 255] * (y / 2))) >> 7) + 64) & 127);
                  yy = (char)((((y2) >> 7) + 32) & 63);
               }

               Brush br = Brushes.Black;

               if ( effect == 0 )
               {
                  if ((((xx >>3) & 1) ^ ((yy >>3) & 1)) == 0)
                     br = Brushes.White;
               }
               else if ( effect == 1 )
               {
                  if ((pic[xx + (yy >> 3) * 128] & (1 << (yy & 7))) == 0)
                     br = Brushes.White;
               }
               else if ( effect == 2 )
               {
                  if (ScrollText(xx, yy, time) == 0)
                     br = Brushes.White;
               }
               else if (effect == 3)
               {
                  if ( yy>=32-8 && yy<32+8) 
                     if ( sin_lut[ (xx+time*10) & 255 ] >>4 == (yy-32))
                        br = Brushes.White;
               }

               g.FillRectangle(br, x * 2, y * 2, 1 * 2, 1 * 2);

               x2 += _cos;
               y2 -= _sin;
            
            }

            x1 += _sin;
            y1 += _cos;

         }
      }

      private void Form1_Paint(object sender, PaintEventArgs e)
      {
         Roto(e.Graphics, m_pic);
         //Starfield(e.Graphics);
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
         time++;
         if ( checkBox1.Checked == true)
            aa++;

         limits=8;//++;
         //z += zz;

         if (z > 200)
            zz = -2;
         if (z < 10)
            zz = 2;

         Invalidate();
         
      }

      private void trackBar1_Scroll(object sender, EventArgs e)
      {
         effect = (byte)trackBar1.Value;         
      }

      private void trackBar2_Scroll(object sender, EventArgs e)
      {
         num_stars = (byte)trackBar2.Value;     
      }
   }
}
