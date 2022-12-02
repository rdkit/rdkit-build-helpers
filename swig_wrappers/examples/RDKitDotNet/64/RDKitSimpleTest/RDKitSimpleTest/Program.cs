using System;
using System.IO;
using GraphMolWrap;

namespace RDKitSimpleTest
{
    internal class Program
    {
        static string drawOptions =
            "{\n" +
            "  \"bondLineWidth\": 0.7,\n" +
            "  \"multipleBondOffset\": 0.25,\n" +
            "  \"fixedScale\": 0.08,\n" +
            "  \"baseFontSize\": 1.0,\n" +
            "  \"minFontSize\": -1,\n" +
            "  \"maxFontSize\": -1,\n" +
            "  \"annotationFontScale\": 0.7,\n" +
            "  \"highlightBondWidthMultiplier\": 20,\n" +
            "  \"dummyIsotopeLabels\": false,\n" +
            "  \"atomColourPalette\": {\n" +
            "    \"0\": [\n" +
            "      0.1,\n" +
            "      0.1,\n" +
            "      0.1\n" +
            "    ],\n" +
            "    \"1\": [\n" +
            "      0,\n" +
            "      0,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"6\": [\n" +
            "      0,\n" +
            "      0,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"7\": [\n" +
            "      0,\n" +
            "      0,\n" +
            "      1\n" +
            "    ],\n" +
            "    \"8\": [\n" +
            "      1,\n" +
            "      0,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"9\": [\n" +
            "      0,\n" +
            "      0.498,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"15\": [\n" +
            "      0.498,\n" +
            "      0,\n" +
            "      0.498\n" +
            "    ],\n" +
            "    \"16\": [\n" +
            "      0.498,\n" +
            "      0.247,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"17\": [\n" +
            "      0,\n" +
            "      0.498,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"35\": [\n" +
            "      0,\n" +
            "      0.498,\n" +
            "      0\n" +
            "    ],\n" +
            "    \"53\": [\n" +
            "      0.247,\n" +
            "      0,\n" +
            "      0.498\n" +
            "    ]\n" +
            "  },\n" +
            "  \"backgroundColour\": [\n" +
            "    1,\n" +
            "    1,\n" +
            "    1,\n" +
            "    1\n" +
            "  ]\n" +
            "}\n";
        static void Main(string[] args)
        {
            string structure = "\n     RDKit          2D\n\n 34 37  0  0  0  0  0  0  0  0999 V2000\n  -10.7962    1.5348    0.0000 O   0  0  0  0  0  0  0  0  0  0  0  0\n  -10.0687    0.2230    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n  -10.8410   -1.0629    0.0000 O   0  0  0  0  0  0  0  0  0  0  0  0\n   -8.5689    0.1972    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -7.0692    0.1713    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -6.2969    1.4573    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -4.7971    1.4314    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -4.0696    0.1197    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -4.8419   -1.1663    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -6.3416   -1.1404    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -2.5698    0.0938    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -1.8423   -1.2179    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -0.3425   -1.2438    0.0000 N   0  0  0  0  0  0  0  0  0  0  0  0\n    0.3850   -2.5555    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    1.8848   -2.5814    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    2.6570   -1.2954    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    4.1568   -1.3213    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    5.0174   -2.5498    0.0000 N   0  0  0  0  0  0  0  0  0  0  0  0\n    6.4518   -2.1109    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    7.7377   -2.8832    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    9.0495   -2.1557    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    9.0753   -0.6559    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    7.7894    0.1164    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    6.4776   -0.6111    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    5.0592   -0.1231    0.0000 N   0  0  0  0  0  0  0  0  0  0  0  0\n    4.6204    1.3112    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    5.6431    2.4085    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    5.2042    3.8429    0.0000 O   0  0  0  0  0  0  0  0  0  0  0  0\n    6.2270    4.9401    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    5.7881    6.3745    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    1.9295    0.0163    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n    0.4297    0.0422    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -8.5948   -1.3026    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n   -8.5431    1.6969    0.0000 C   0  0  0  0  0  0  0  0  0  0  0  0\n  1  2  2  0\n  2  3  1  0\n  2  4  1  0\n  4  5  1  0\n  5  6  2  0\n  6  7  1  0\n  7  8  2  0\n  8  9  1  0\n  9 10  2  0\n  8 11  1  0\n 11 12  1  0\n 12 13  1  0\n 13 14  1  0\n 14 15  1  0\n 15 16  1  0\n 16 17  1  0\n 17 18  2  0\n 18 19  1  0\n 19 20  2  0\n 20 21  1  0\n 21 22  2  0\n 22 23  1  0\n 23 24  2  0\n 24 25  1  0\n 25 26  1  0\n 26 27  1  0\n 27 28  1  0\n 28 29  1  0\n 29 30  1  0\n 16 31  1  0\n 31 32  1  0\n  4 33  1  0\n  4 34  1  0\n 10  5  1  0\n 25 17  1  0\n 24 19  1  0\n 32 13  1  0\nM  END\n";
            ROMol molFromCTab = RWMol.MolFromMolBlock(structure);
            molFromCTab.normalizeDepiction(-1, 0);
            molFromCTab.straightenDepiction(-1, true);
            using (MolDraw2DCairo molDraw = new MolDraw2DCairo(300, 250))
            {
                RDKFuncs.updateDrawerParamsFromJSON(molDraw, drawOptions);
                molDraw.drawMolecule(molFromCTab);
                molDraw.finishDrawing();
                UChar_Vect pngUCharVect = molDraw.getImage();
                byte[] pngBytes = new byte[pngUCharVect.Count];
                pngUCharVect.CopyTo(pngBytes);
                string rdkString = Convert.ToBase64String(pngBytes);
                Console.WriteLine("RDKit Base64String:");
                Console.WriteLine(rdkString);
            }

            ROMol erythromycin = RWMol.MolFromSmiles("CC[C@@H]1[C@@]([C@@H]([C@H](C(=O)[C@@H](C[C@@]([C@@H]([C@H]([C@@H]([C@H](C(=O)O1)C)O[C@H]2C[C@@]([C@H]([C@@H](O2)C)O)(C)OC)C)O[C@H]3[C@@H]([C@H](C[C@H](O3)C)N(C)C)O)(C)O)C)C)O)(C)O");
            using (MolDraw2DSVG molDraw = new MolDraw2DSVG(300, 250))
            {
                RDKFuncs.setPreferCoordGen(true);
                erythromycin.compute2DCoords();
                RDKFuncs.setPreferCoordGen(false);
                erythromycin.normalizeDepiction();
                erythromycin.straightenDepiction();
                RDKFuncs.updateDrawerParamsFromJSON(molDraw, drawOptions);
                molDraw.drawMolecule(erythromycin);
                molDraw.finishDrawing();
                string svg = molDraw.getDrawingText();
                File.WriteAllText("C:/Temp/erythromycin_csharp.svg", svg);
            }

            string smiles = "CNCCNc1nc(nc2cc(ccc12)N3CCN(CC3)C(=O)/C=C/C4C=NN(C)C=4)C5(CCCC5)c6ccc(Cl)cc6";

            ROMol mol = RWMol.MolFromSmiles(smiles);
            using (MolDraw2DCairo molDraw = new MolDraw2DCairo(200, 150))
            {
                RDKFuncs.updateDrawerParamsFromJSON(molDraw, drawOptions);
                mol.compute2DCoords();
                mol.normalizeDepiction();
                mol.straightenDepiction();
                molDraw.drawMolecule(mol);
                molDraw.finishDrawing();
                molDraw.writeDrawingText("C:/Temp/rdkitSmiles.png");
            }
            using (MolDraw2DCairo molDraw = new MolDraw2DCairo(200, 150))
            {
                RDKFuncs.updateDrawerParamsFromJSON(molDraw, drawOptions);
                RDKFuncs.setPreferCoordGen(true);
                mol.compute2DCoords();
                Console.WriteLine($"RDKFuncs.getPreferCoordGen {RDKFuncs.getPreferCoordGen()}");
                RDKFuncs.setPreferCoordGen(false);
                mol.normalizeDepiction();
                mol.straightenDepiction();
                molDraw.drawMolecule(mol);
                molDraw.finishDrawing();
                molDraw.writeDrawingText("C:/Temp/coordgenSmiles.png");
            }
        }
    }
}
