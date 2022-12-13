/*
Linux
-----
CLASSPATH=/scratch/toscopa1/src/bitbucket/rdkit-build-helpers/swig_wrappers/artifacts/java/noarch/org.RDKit.jar:. \
LD_LIBRARY_PATH=/scratch/toscopa1/src/bitbucket/rdkit-build-helpers/swig_wrappers/artifacts/java/linux/x86_64 \
javac RDKitDepiction.java && \
CLASSPATH=/scratch/toscopa1/src/bitbucket/rdkit-build-helpers/swig_wrappers/artifacts/java/noarch/org.RDKit.jar:. \
LD_LIBRARY_PATH=/scratch/toscopa1/src/bitbucket/rdkit-build-helpers/swig_wrappers/artifacts/java/linux/x86_64 \
java -Djava.library.path=/scratch/toscopa1/src/bitbucket/rdkit-build-helpers/swig_wrappers/artifacts/java/linux/x86_64 RDKitDepiction

Windows
-------
set CLASSPATH=C:\build\src\rdkit-build-helpers\swig_wrappers\artifacts\java\noarch\org.RDKit.jar;. & ^
javac RDKitDepiction.java & ^
java -Djava.library.path=C:\build\src\rdkit-build-helpers\swig_wrappers\artifacts\java\windows\x86_64 RDKitDepiction


*/

import org.RDKit.*;
import java.io.PrintWriter;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStream;

class RDKitDepiction {
    public static void main(String args[]) throws IOException {
        System.loadLibrary("GraphMolWrap");

        String drawOptions =
            "{\n" +
            "  \"bondLineWidth\": 1.1,\n" +
            "  \"multipleBondOffset\": 0.25,\n" +
            "  \"fixedScale\": 0.08,\n" +
            "  \"baseFontSize\": 1,\n" +
            "  \"minFontSize\": -1,\n" +
            "  \"maxFontSize\": -1,\n" +
            "  \"annotationFontScale\": 0.7,\n" +
            "  \"highlightBondWidthMultiplier\": 12,\n" +
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
        String smiles = "CC1(C(N2C(S1)C(C2=O)NC(=O)CC3=CC=CC=C3)C(=O)O)C";
        ROMol mol = RWMol.MolFromSmiles(smiles);
        MolDraw2DCairo molDraw = new MolDraw2DCairo(-1, -1);
        RDKFuncs.updateDrawerParamsFromJSON(molDraw, drawOptions);
        mol.compute2DCoords();
        molDraw.drawMolecule(mol);
        molDraw.finishDrawing();
        byte[] pngBytes = molDraw.toByteArray();
        File file = new File("image.png");
        OutputStream os = new FileOutputStream(file);
        os.write(pngBytes);
        os.close();
    }
}
