var qrtemp;
var QRDiv;
function QRCodeEncoder(fLogResults) { var g_ExponentOf2Map = null; var g_logOf2Map = [-1]; var g_QRCodeGeneratorPolynomials = [[]]; var eccLevelEnum = { "M": 0, "L": 1, "H": 2, "Q": 3 }; var versionEnum = { "modulesPerSide": 0, "modulesInFunctionPatterns": 1, "modulesInFormatAndVersion": 2, "modulesInData": 3, "dataCapacity": 4, "remainderBits": 5, "genPoly": 6, "codeBlocks": 7, "alignPaternTopLeft": 8 }; var g_rgVersions = [null, [21, 202, 31, 208, 26, 0, [10, 7, 17, 13], [1, 1, 1, 1], []], [25, 235, 31, 359, 44, 7, [16, 10, 28, 22], [1, 1, 1, 1], [4, 16]], [29, 243, 31, 567, 70, 7, [26, 15, 22, 18], [1, 1, 2, 2], [4, 20]], [33, 251, 31, 807, 100, 7, [18, 20, 16, 26], [2, 1, 4, 2], [4, 24]], [37, 259, 31, 1079, 134, 7, [24, 26, 22, 18], [2, 1, 4, 4], [4, 28]], [41, 267, 31, 1383, 172, 7, [16, 18, 28, 24], [4, 2, 4, 4], [4, 32]], [45, 390, 67, 1568, 196, 0, [18, 20, 26, 18], [4, 2, 5, 6], [4, 20, 36]], [49, 398, 67, 1936, 242, 0, [22, 24, 26, 22], [4, 2, 6, 6], [4, 22, 40]], [53, 406, 67, 2336, 292, 0, [22, 30, 24, 20], [5, 2, 8, 8], [4, 24, 44]], [57, 414, 67, 2768, 346, 0, [26, 18, 28, 24], [5, 4, 8, 8], [4, 26, 48]], [61, 422, 67, 3232, 404, 0, [30, 20, 24, 28], [5, 4, 11, 8], [4, 28, 52]], [65, 430, 67, 3728, 466, 0, [22, 24, 28, 26], [8, 4, 11, 10], [4, 30, 56]], [69, 438, 67, 4256, 532, 0, [22, 26, 22, 24], [9, 4, 16, 12], [4, 32, 60]], [73, 611, 67, 4651, 581, 3, [24, 30, 24, 20], [9, 4, 16, 16], [4, 24, 44, 64]], [77, 619, 67, 5243, 655, 3, [24, 22, 24, 30], [10, 6, 18, 12], [4, 24, 46, 68]], [81, 627, 67, 5867, 733, 3, [28, 24, 30, 24], [10, 6, 16, 17], [4, 24, 48, 72]], [85, 635, 67, 6523, 815, 3, [28, 28, 28, 28], [11, 6, 19, 16], [4, 28, 52, 76]], [89, 643, 67, 7211, 901, 3, [26, 30, 28, 28], [13, 6, 21, 18], [4, 28, 54, 80]], [93, 651, 67, 7931, 991, 3, [26, 28, 26, 26], [14, 7, 25, 21], [4, 28, 56, 84]], [97, 659, 67, 8683, 1085, 3, [26, 28, 28, 30], [16, 8, 25, 20], [4, 32, 60, 88]], [101, 882, 67, 9252, 1156, 4, [26, 28, 30, 28], [17, 8, 25, 23], [4, 26, 48, 70, 92]], [105, 890, 67, 10068, 1258, 4, [28, 28, 24, 30], [17, 9, 34, 23], [4, 24, 48, 72, 96]], [109, 898, 67, 10916, 1364, 4, [28, 30, 30, 30], [18, 9, 30, 25], [4, 28, 52, 76, 100]], [113, 906, 67, 11796, 1474, 4, [28, 30, 30, 30], [20, 10, 32, 27], [4, 26, 52, 78, 104]], [117, 914, 67, 12708, 1588, 4, [28, 26, 30, 30], [21, 12, 35, 29], [4, 30, 56, 82, 108]], [121, 922, 67, 13652, 1706, 4, [28, 28, 30, 28], [23, 12, 37, 34], [4, 28, 56, 84, 112]], [125, 930, 67, 14628, 1828, 4, [28, 30, 30, 30], [25, 12, 40, 34], [4, 32, 60, 88, 116]], [129, 1203, 67, 15371, 1921, 3, [28, 30, 30, 30], [26, 13, 42, 35], [4, 24, 48, 72, 96, 120]], [133, 1211, 67, 16411, 2051, 3, [28, 30, 30, 30], [28, 14, 45, 38], [4, 28, 52, 76, 100, 124]], [137, 1219, 67, 17483, 2185, 3, [28, 30, 30, 30], [29, 15, 48, 40], [4, 24, 50, 76, 102, 128]], [141, 1227, 67, 18587, 2323, 3, [28, 30, 30, 30], [31, 16, 51, 43], [4, 28, 54, 80, 106, 132]], [145, 1235, 67, 19723, 2465, 3, [28, 30, 30, 30], [33, 17, 54, 45], [4, 32, 58, 84, 110, 136]], [149, 1243, 67, 20891, 2611, 3, [28, 30, 30, 30], [35, 18, 57, 48], [4, 28, 56, 84, 112, 140]], [153, 1251, 67, 22091, 2761, 3, [28, 30, 30, 30], [37, 19, 60, 51], [4, 32, 60, 88, 116, 144]], [157, 1574, 67, 23008, 2876, 0, [28, 30, 30, 30], [38, 19, 63, 53], [4, 28, 52, 76, 100, 124, 148]], [161, 1582, 67, 24272, 3034, 0, [28, 30, 30, 30], [40, 20, 66, 56], [4, 22, 48, 74, 100, 126, 152]], [165, 1590, 67, 25568, 3196, 0, [28, 30, 30, 30], [43, 21, 70, 59], [4, 26, 52, 78, 104, 130, 156]], [169, 1598, 67, 26896, 3362, 0, [28, 30, 30, 30], [45, 22, 74, 62], [4, 30, 56, 82, 108, 134, 160]], [173, 1606, 67, 28256, 3532, 0, [28, 30, 30, 30], [47, 24, 77, 65], [4, 24, 52, 80, 108, 136, 164]], [177, 1614, 67, 29648, 3706, 0, [28, 30, 30, 30], [49, 25, 81, 68], [4, 28, 56, 84, 112, 140, 168]]]; var g_QrMaskFunctions = [function (i, j) { return (i + j) % 2 == 0; }, function (i, j) { return i % 2 == 0; }, function (i, j) { return j % 3 == 0; }, function (i, j) { return (i + j) % 3 == 0; }, function (i, j) { return ((i / 2 | 0) + (j / 3 | 0)) % 2 == 0; }, function (i, j) { return i * j % 2 + i * j % 3 == 0; }, function (i, j) { return (i * j % 2 + i * j % 3) % 2 == 0; }, function (i, j) { return ((i + j) % 2 + i * j % 3) % 2 == 0; }]; var g_Finder1 = "1111111"; var g_Finder2 = "1000001"; var g_Finder3 = "1011101"; var g_finderTopLeft = [g_Finder1 + "00", g_Finder2 + "00", g_Finder3 + "00", g_Finder3 + "00", g_Finder3 + "00", g_Finder2 + "00", g_Finder1 + "00", "000000000", "000000000"]; var g_finderTopRight = ["0" + g_Finder1, "0" + g_Finder2, "0" + g_Finder3, "0" + g_Finder3, "0" + g_Finder3, "0" + g_Finder2, "0" + g_Finder1, "00000000", "00000000"]; var g_finderBottomLeft = ["000000001", g_Finder1 + "00", g_Finder2 + "00", g_Finder3 + "00", g_Finder3 + "00", g_Finder3 + "00", g_Finder2 + "00", g_Finder1 + "00"]; var g_Align1 = "11111"; var g_Align2 = "10001"; var g_Align3 = "10101"; var g_Align = [g_Align1, g_Align2, g_Align3, g_Align2, g_Align1]; var g_VersionInfoGeneratorPoly = 0x1F25; var g_FormatInfoGeneratorPoly = 0x537; var g_one = 1; var g_zero = 0; var g_staticZero = 2; var g_staticOne = 3; var g_modeTerminator = 0; var g_rgBadPattern1 = 0x5D; var g_rgBadPattern2 = 0x5D0; var g_rgBadPatternMask = 0x7FF; var logObj = fLogResults ? {} : null; var logMask = fLogResults ? { "maskFuncScores": [] } : null; var _rgqrMatrix = null; var _moduleSize = 5; var _marginSize = 4; var _mask = 0; var _eccLevel = eccLevelEnum.L; var _version = -1; InitPolynomialMaps(); return { "generateElement": _GenerateQrElement, "generateImg": _GenerateQrImg, "generateHTML": _GenerateQrHTML, "moduleSize": _ModuleSize, "eccLevel": _EccLevel, "margin": function (m) { if (m != null) _marginSize = m; return _marginSize; }, "getLog": function () { return logObj; } }; function _ModuleSize(modSize) { if (modSize != null && modSize > 0 && modSize < 100) { _moduleSize = modSize; } return _moduleSize; } function _EccLevel(eccLevel) { if (eccLevel != null && eccLevel >= 0 && eccLevel <= 3) { _eccLevel = eccLevel; } return _eccLevel; } function logResults(propName, propValue) { if (logObj != null) { logObj[propName] = propValue; } } function logMaskScores(n1s, n2s, n3s, k, score) { if (logMask != null) { var maskObj = {}; maskObj.n1s = n1s; maskObj.n2s = n2s; maskObj.n3s = n3s; maskObj.k = k; maskObj.score = score; logMask.maskFuncScores.push(maskObj); } } function InitPolynomialMaps() { if (g_ExponentOf2Map != null) { return; } GenerateExponentAndLogTables(); GenerateAllQRCodePolynomials(); logResults("expMap", JSON.stringify(g_ExponentOf2Map)); logResults("logMap", JSON.stringify(g_logOf2Map)); logResults("genPoly", JSON.stringify(g_QRCodeGeneratorPolynomials)); } function GenerateExponentAndLogTables() { var value = 1; g_ExponentOf2Map = []; for (var i = 0; i < 255; ++i) { g_ExponentOf2Map.push(value); g_logOf2Map[value] = i; value = value * 2 ^ (value >= 128 ? 0x11d : 0); } } function GenerateAllQRCodePolynomials() { var poly = []; for (var i = 0; i < 30; i++) { poly = GeneratePolynomial(i, poly); g_QRCodeGeneratorPolynomials.push(poly); } } function GeneratePolynomial(k, previousPoly) { var poly = []; for (var i = 0; i <= k; i++) { var a = i < k ? g_ExponentOf2Map[previousPoly[i]] : 0; var previousCoefficient = i == 0 ? 0 : previousPoly[(i - 1)]; var b = g_ExponentOf2Map[((k + previousCoefficient) % 255)]; poly.push(g_logOf2Map[(a ^ b)]); } return poly; } function _GenerateQrImg(strData, settings) { if (_rgqrMatrix == null) { _rgqrMatrix = Generate2DBitArray(strData, settings); } return ImgFromMatrix(_rgqrMatrix, _moduleSize, _marginSize); } function _GenerateQrHTML(strData, settings) { if (_rgqrMatrix == null) { _rgqrMatrix = Generate2DBitArray(strData, settings); } return HTMLFromMatrix(_rgqrMatrix, _moduleSize, _marginSize); } function _GenerateQrElement(strData, settings) { if (_rgqrMatrix == null || strData != null) { _rgqrMatrix = Generate2DBitArray(strData, settings); } return ElementFromMatrix(_rgqrMatrix, _moduleSize, _marginSize); } function Generate2DBitArray(strData, settings) { settings = settings == null ? {} : settings; if (!validateInputs(strData, settings)) throw "invalid input"; _moduleSize = settings.moduleSize == null ? 5 : settings.moduleSize; _marginSize = settings.marginSize == null ? 4 : settings.marginSize; var rgBytes = StringToByteArray(strData); _version = getQRVersion(rgBytes); logResults("version", JSON.stringify(_version)); var verRow = g_rgVersions[_version]; var rgResultBytes = EncodeToRawByteStream(_version, rgBytes); logResults("rawData", JSON.stringify(rgResultBytes)); rgResultBytes = IncorporateEccCodeWords(rgResultBytes, verRow[versionEnum.codeBlocks][_eccLevel], g_QRCodeGeneratorPolynomials[verRow[versionEnum.genPoly][_eccLevel]]); logResults("dataStream", JSON.stringify(rgResultBytes)); var rgqrMatrix = CreateMatrixWithStaticContent(_version); logResults("functionPatterns", JSON.stringify(rgqrMatrix, 1)); InsertDataIntoMatrix(rgqrMatrix, rgResultBytes); logResults("matrixWithFunctionAndData", JSON.stringify(rgqrMatrix)); _mask = MaskQRCode(_version, _eccLevel, rgqrMatrix); logResults("maskIndex", JSON.stringify(_mask)); logResults("finalQrMatrix", JSON.stringify(rgqrMatrix)); logResults("maskInfo", JSON.stringify(logMask)); return rgqrMatrix; } function StringToByteArray(data) { var rgBytes = []; var strLen = data.length; for (var i = 0; i < strLen; ++i) { var ch = data.charCodeAt(i); if (ch < 0x80) { rgBytes.push(ch); } else if (ch < 0x800) { rgBytes.push((0xc0 | ch >> 6), (0x80 | ch & 0x3f)); } else if (ch < 0x10000) { rgBytes.push((0xe0 | ch >> 12), (0x80 | ch >> 6 & 0x3f), (0x80 | ch & 0x3f)); } else { rgBytes.push((0xf0 | ch >> 18), (0x80 | ch >> 12 & 0x3f), (0x80 | ch >> 6 & 0x3f), (0x80 | ch & 0x3f)); } } return rgBytes; } function BitArray() { var _rgBytes = []; var _byteCurrent = 0; var _cBitsRemainingInCurByte = 8; this.getByteArray = function () { return _rgBytes; }; this.pushLastByte = function () { if (_cBitsRemainingInCurByte < 8) { _rgBytes.push(_byteCurrent); } }; this.pushBits = function (data, cbitLen) { if (cbitLen >= _cBitsRemainingInCurByte) { cbitLen = cbitLen - _cBitsRemainingInCurByte; var remainingCurrentByteData = data >> cbitLen; _rgBytes.push((_byteCurrent | remainingCurrentByteData)); while (cbitLen >= 8) { cbitLen = cbitLen - 8; _rgBytes.push((data >> cbitLen & 255)); } _byteCurrent = 0; _cBitsRemainingInCurByte = 8; } if (cbitLen > 0) { _cBitsRemainingInCurByte = _cBitsRemainingInCurByte - cbitLen; var bitsToPush = data & (1 << cbitLen) - 1; _byteCurrent |= bitsToPush << _cBitsRemainingInCurByte; } }; } function EncodeToRawByteStream(ver, rgBytes) { var nMaxDataBytes = GetMaxDataBits(ver, _eccLevel) + 4 + BitCountDataLength(ver) >> 3; var bitArray = new BitArray(); bitArray.pushBits(4, 4); bitArray.pushBits(rgBytes.length, BitCountDataLength(ver)); for (var i = 0; i < rgBytes.length; ++i) { bitArray.pushBits(rgBytes[i], 8); } bitArray.pushBits(g_modeTerminator, 4); bitArray.pushLastByte(); var rgRawBytes = bitArray.getByteArray(); while (rgRawBytes.length + 1 < nMaxDataBytes) { rgRawBytes.push(0xec); rgRawBytes.push(0x11); } if (rgRawBytes.length < nMaxDataBytes) { rgRawBytes.push(0xec); } return rgRawBytes; } function IncorporateEccCodeWords(rgBytes, cCodeBlocks, rgGeneratorPolynomial) { if (cCodeBlocks > rgBytes.length) throw ""; var rgBlockMarkers = []; var cBytes = rgBytes.length; var cSizeOfEachCodeBlock = Math.floor((cBytes / cCodeBlocks)); var cRemainderBytes = cBytes % cCodeBlocks; var iStartOfBlock = 0; for (var i = 0; i < cCodeBlocks; i++) { if (cRemainderBytes > 0 && i > cCodeBlocks - cRemainderBytes) { iStartOfBlock += 1; } rgBlockMarkers.push(iStartOfBlock); iStartOfBlock += cSizeOfEachCodeBlock; } var rgEccCodeWordsInBlock = []; var rgBlocksOfBytes = []; for (i = 0; i < cCodeBlocks; i++) { var rgBytesInCurrentBlock = i < cCodeBlocks - 1 ? rgBytes.slice(rgBlockMarkers[i], rgBlockMarkers[(i + 1)]) : rgBytes.slice(rgBlockMarkers[i]); rgBlocksOfBytes.push(rgBytesInCurrentBlock); var rgEccCodeWordsForBlock = GenEccCodeWordsFromInputBlock(rgBytesInCurrentBlock, rgGeneratorPolynomial); rgEccCodeWordsInBlock.push(rgEccCodeWordsForBlock); } return MergeDataAndEccBlocks(rgBlocksOfBytes, rgEccCodeWordsInBlock); } function MergeDataAndEccBlocks(rgBlocksOfBytes, rgEccCodeWordsInBlock) { var rgResult = []; MergeBytes(rgBlocksOfBytes, rgResult); MergeBytes(rgEccCodeWordsInBlock, rgResult); return rgResult; } function MergeBytes(rgBlocksOfBytes, rgResult) { var cBlocks = rgBlocksOfBytes.length; var cBytesInFirstBlock = rgBlocksOfBytes[0].length; for (var i = 0; i < cBytesInFirstBlock + 1; i++) { for (var j = 0; j < cBlocks; j++) { if (i < rgBlocksOfBytes[j].length) { rgResult.push(rgBlocksOfBytes[j][i]); } } } } function BCHify(input, cBitsInput, cBitsGeneratorPolynomial, generatorPolynomial) { var modifiedInput = input << cBitsGeneratorPolynomial; var remainder = modifiedInput; for (var i = cBitsInput - 1; i >= 0; i--) { if (Boolean((remainder >> cBitsGeneratorPolynomial + i & 1))) { remainder ^= generatorPolynomial << i; } } return modifiedInput | remainder; } function GenerateFormatBits(ecc, iMask) { var formatInfo = ecc << 3 | iMask; var formatInfoFinalBits = BCHify(formatInfo, 5, 10, g_FormatInfoGeneratorPoly); return formatInfoFinalBits ^ 0x5412; } function GetVersionBits(ver) { return BCHify(ver, 6, 12, g_VersionInfoGeneratorPoly); } function GenEccCodeWordsFromInputBlock(rgInputBytes, rgGeneratorPolynomial) { var rgInputBytesCopy = rgInputBytes.slice(0); var cBytesGenPoly = rgGeneratorPolynomial.length; var cBytesInput = rgInputBytesCopy.length; for (var i = 0; i < cBytesGenPoly; ++i) { rgInputBytesCopy.push(0); } for (i = 0; i < cBytesInput;) { var log2OfByte = g_logOf2Map[rgInputBytesCopy[(i++)]]; if (log2OfByte >= 0) { for (var j = 0; j < cBytesGenPoly; ++j) { rgInputBytesCopy[(i + j)] ^= g_ExponentOf2Map[((log2OfByte + rgGeneratorPolynomial[j]) % 255)]; } } } return rgInputBytesCopy.slice(cBytesInput); } function CreateMatrixWithStaticContent(ver) { var qrMatrix = []; var modulesPerSide = g_rgVersions[ver][versionEnum.modulesPerSide]; for (var i = 0; i < modulesPerSide; i++) { var row = []; for (var j = 0; j < modulesPerSide; j++) { row.push(null); } qrMatrix.push(row); } staticBlast(qrMatrix, 0, 0, g_finderTopLeft); staticBlast(qrMatrix, 0, (modulesPerSide - 8), g_finderBottomLeft); staticBlast(qrMatrix, (modulesPerSide - 8), 0, g_finderTopRight); for (i = 8; i < modulesPerSide - 8; ++i) { qrMatrix[6][i] = Boolean((~i & 1)) ? g_staticOne : g_staticZero; qrMatrix[i][6] = Boolean((~i & 1)) ? g_staticOne : g_staticZero; } var rgAlignmentPoints = g_rgVersions[ver][versionEnum.alignPaternTopLeft]; var cAlignmentPatterns = rgAlignmentPoints.length; for (i = 0; i < cAlignmentPatterns; ++i) { var first = i == 0 || i == cAlignmentPatterns - 1 ? 1 : 0; var last = i == 0 ? cAlignmentPatterns - 1 : cAlignmentPatterns; for (j = first; j < last; ++j) { staticBlast(qrMatrix, rgAlignmentPoints[j], rgAlignmentPoints[i], g_Align); } } if (FQrCodeNeedsVersionBits(ver)) { var bchEncodedVersionInfo = GetVersionBits(ver); var curBitPosition = 0; for (i = 0; i < 6; ++i) { for (j = 0; j < 3; ++j) { var curModule = bchEncodedVersionInfo >> curBitPosition & 1; qrMatrix[i][(modulesPerSide - 11 + j)] = Boolean(curModule) ? g_staticOne : g_staticZero; qrMatrix[(modulesPerSide - 11 + j)][i] = Boolean(curModule) ? g_staticOne : g_staticZero; curBitPosition++; } } } return qrMatrix; } function staticBlast(qrMatrix, x, y, arr) { for (var row = 0; row < arr.length; row++) { var strRow = arr[row]; for (var col = 0; col < strRow.length; col++) { var rowFinal = y + row; var colFinal = x + col; qrMatrix[rowFinal][colFinal] = strRow.charAt(col) == "1" ? g_staticOne : g_staticZero; } } } function InsertDataIntoMatrix(qrMatrix, buf) { var n = qrMatrix.length; var iCurrentBit = 0, dir = -1; for (var col = n - 1; col >= 0; col -= 2) { if (col == 6) col--; var rowFinal = dir < 0 ? n - 1 : 0; for (var j = 0; j < n; j++) { for (var colFinal = col; colFinal > col - 2; --colFinal) { if (qrMatrix[rowFinal][colFinal] == null) { var byteCurrent = buf[(iCurrentBit >> 3)]; var bitPosInByteCurrent = 7 - (iCurrentBit & 7); var bitCurrent = byteCurrent >> bitPosInByteCurrent; qrMatrix[rowFinal][colFinal] = Boolean((bitCurrent & 1)) ? g_one : g_zero; iCurrentBit++; } } rowFinal += dir; } dir = -dir; } } function ApplyMaskToData(qrMatrix, iMaskFunc) { var fnMask = g_QrMaskFunctions[iMaskFunc]; var modulesPerSide = qrMatrix.length; for (var i = 0; i < modulesPerSide; i++) { for (var j = 0; j < modulesPerSide; j++) { var bitVal = qrMatrix[i][j]; var fStaticModule = bitVal >> 1 & 1; if (!fStaticModule) { qrMatrix[i][j] = bitVal ^ fnMask(i, j); } } } } function MaskQRCode(ver, ecc, qrMatrix) { var iBestMaskIndex = 0; var bestScore = 0xFFFFFFFF; for (var i = 0; i < g_QrMaskFunctions.length; i++) { ApplyMaskToData(qrMatrix, i); InsertFormatInfoIntoMatrix(qrMatrix, ecc, i); var maskScore = CalculateMaskScore(qrMatrix); if (maskScore < bestScore) { bestScore = maskScore; iBestMaskIndex = i; } ApplyMaskToData(qrMatrix, i); } ApplyMaskToData(qrMatrix, iBestMaskIndex); InsertFormatInfoIntoMatrix(qrMatrix, ecc, iBestMaskIndex); return iBestMaskIndex; } function CalculateMaskScore(qrMatrix) { var prevBit = null; var adjacentScore = 0; var n1s = 0; var n2s = 0; var n3s = 0; var score = 0; var calcAdjacentPattern = function (currentBit) { if (prevBit == currentBit) { adjacentScore++; } else { if (adjacentScore >= 5) { score += 3 + (adjacentScore - 5); n1s++; } adjacentScore = 1; } prevBit = currentBit; }; var modulesPerSide = qrMatrix.length; var cDarkModules = 0; var stateMachineForBadPattern1 = StateMachine(g_rgBadPattern1, false, true); var stateMachineForBadPattern2 = StateMachine(g_rgBadPattern2, true, false); for (var row = 0; row < modulesPerSide; row++) { stateMachineForBadPattern1.reset(); stateMachineForBadPattern2.reset(); prevBit = null; adjacentScore = 0; for (var col = 0; col < modulesPerSide; col++) { var curVal = qrMatrix[row][col]; var curBit = curVal == g_one || curVal == g_staticOne ? g_one : g_zero; calcAdjacentPattern(curBit); var boxScore = 0; var maxRow = row == modulesPerSide - 1 ? row : row + 1; var maxCol = col == modulesPerSide - 1 ? col : col + 1; for (var subRow = row; subRow <= maxRow; subRow++) { for (var subCol = col; subCol <= maxCol; subCol++) { if (subRow == row && subCol == col) continue; var compareVal = qrMatrix[subRow][subCol]; var compareBit = compareVal == g_one || compareVal == g_staticOne ? g_one : g_zero; if (subRow >= row && subCol >= col) { boxScore += curBit == compareBit ? 1 : 0; } } } if (boxScore >= 3) { score += 3; n2s++; } if (curBit == g_one) cDarkModules++; var nextBit = col == modulesPerSide - 1 ? -1 : qrMatrix[row][(col + 1)]; if (nextBit != -1) { nextBit = nextBit == g_one || nextBit == g_staticOne ? g_one : g_zero; } if (stateMachineForBadPattern1.checkState(curBit, nextBit) == true || stateMachineForBadPattern2.checkState(curBit, nextBit) == true) { score += 40; n3s++; } } calcAdjacentPattern(null); } var k = Math.abs((0.5 - cDarkModules / (modulesPerSide * modulesPerSide))); k = Math.floor((k / .05)); score += k * 10; for (col = 0; col < modulesPerSide; col++) { stateMachineForBadPattern1.reset(); stateMachineForBadPattern2.reset(); prevBit = null; adjacentScore = 1; for (row = 0; row < modulesPerSide; row++) { curVal = qrMatrix[row][col]; curBit = curVal == g_one || curVal == g_staticOne ? g_one : g_zero; nextBit = row == modulesPerSide - 1 ? -1 : qrMatrix[(row + 1)][col]; if (nextBit != -1) { nextBit = nextBit == g_one || nextBit == g_staticOne ? g_one : g_zero; } if (stateMachineForBadPattern1.checkState(curBit, nextBit) == true || stateMachineForBadPattern2.checkState(curBit, nextBit) == true) { score += 40; n3s++; } calcAdjacentPattern(curBit); } calcAdjacentPattern(null); } logMaskScores(n1s, n2s, n3s, k, score); return score; } function InsertFormatInfoIntoMatrix(qrMatrix, ecc, iMask) { var modulesPerSide = qrMatrix.length; var formatInfo = GenerateFormatBits(ecc, iMask); var formatInfoVerticalPlacement = getFormatPlacementVertical(modulesPerSide); var formatInfoHorizPlacement = getFormatPlacementHorizontal(modulesPerSide); for (var i = 0; i < 15; ++i) { var iRow = formatInfoVerticalPlacement[i]; var iCol = formatInfoHorizPlacement[i]; var bit = formatInfo >> i & 1; qrMatrix[iRow][8] = bit; qrMatrix[8][iCol] = bit; } } function ImgFromMatrix(rgMatrix, module_size, marginSize) { var elmCanvas = document.createElement('canvas'); var sizeOfSide = (rgMatrix.length + 2 * marginSize) * module_size; var modulesPerSide = rgMatrix.length; elmCanvas.width = sizeOfSide; elmCanvas.height = sizeOfSide; var context = elmCanvas.getContext('2d'); if (!context) throw 'get a modern browser'; context.fillStyle = '#fff'; context.fillRect(0, 0, sizeOfSide, sizeOfSide); context.fillStyle = '#000'; for (var i = 0; i < modulesPerSide; ++i) { for (var j = 0; j < modulesPerSide; ++j) { if (rgMatrix[i][j] == g_one || rgMatrix[i][j] == g_staticOne) { context.fillRect((module_size * (marginSize + j)), (module_size * (marginSize + i)), module_size, module_size); } } } return elmCanvas.toDataURL(); } function replaceString(str, str0, str1, str2) { if (str0 != null) str = str.replace(/%0%/g, str0); if (str1 != null) str = str.replace(/%1%/g, str1); if (str2 != null) str = str.replace(/%2%/g, str2); return str; } function HTMLFromMatrix(rgMatrix, module_size, marginSize) { var strOuterDivTemplate = "<div style='position:relative;margin:%0%px;width:%1%px;height:%1%px;' >"; var strRowTemplate = "<div style='margin:0px; padding:0px; border:0px; position:absolute;width:%0%px; height:%1%px;top:%2%px;'>"; var strCellTemplate = "<div style='display:inline-block; margin:0px; padding:0px; border:0px; ;position:absolute; width:%0%px; height:%0%px; background-color:%1%;left:%2%px;'></div>"; var rgHTML = []; var modulesPerSide = rgMatrix.length; var qrWidth = modulesPerSide * module_size; rgHTML.push(replaceString(strOuterDivTemplate, (marginSize * module_size).toString(), qrWidth.toString(), null)); for (var row = 0; row < modulesPerSide; row++) { rgHTML.push(replaceString(strRowTemplate, qrWidth.toString(), module_size.toString(), (row * module_size).toString())); for (var col = 0; col < modulesPerSide; col++) { var curVal = rgMatrix[row][col]; var curBit = curVal == g_one || curVal == g_staticOne ? g_one : g_zero; rgHTML.push(replaceString(strCellTemplate, module_size.toString(), (curBit == g_one ? "#000000" : "#ffffff"), (module_size * col).toString())); } rgHTML.push("</div>"); } rgHTML.push("</div>"); return rgHTML.join(""); } function ElementFromMatrix(rgMatrix, module_size, marginSize) { var elmCan = document.createElement('canvas'); if (elmCan != null && elmCan.getContext != null) { var strImgData = ImgFromMatrix(rgMatrix, module_size, marginSize); var elmImg = document.createElement("img"); elmImg.setAttribute("src", strImgData); return elmImg; } else { var strHTML = HTMLFromMatrix(rgMatrix, module_size, marginSize); var elmDiv = document.createElement("div"); elmDiv.innerHTML = strHTML; return elmDiv; } } function BitCountDataLength(ver) { return ver < 10 ? 8 : 16; } function NonDataEncodingBits(ver, ecc) { var rgVer = g_rgVersions[ver]; var nbits = 8 * rgVer[versionEnum.codeBlocks][ecc] * rgVer[versionEnum.genPoly][ecc]; nbits += BitCountDataLength(ver); return nbits; } function GetMaxDataBits(ver, ecc) { var nTotalEncodingBits = g_rgVersions[ver][versionEnum.modulesInData]; nTotalEncodingBits = nTotalEncodingBits & ~7; var nNonDataEncodingBits = NonDataEncodingBits(ver, ecc); return nTotalEncodingBits - nNonDataEncodingBits - 4; } function getQRVersion(data) { var cBytes = data.length; for (var i = 1; i < g_rgVersions.length; i++) { var byteCapacityOfVersion = GetMaxDataBits(i, _eccLevel) / 8 | 0; if (byteCapacityOfVersion >= cBytes) { return i; } } throw "data too large for a QR code"; } function FQrCodeNeedsVersionBits(ver) { return Boolean((ver >= 7)); } function validateInputs(strData, settings) { if (settings != null) { if (settings.moduleSize != null && (settings.moduleSize < 1 || settings.moduleSize > 200)) { throw "invalid moduleSize"; } if (settings.marginSize != null && (settings.marginSize < 1 || settings.marginSize > 200)) { throw "invalid marginSize"; } if (typeof strData === 'string') return true; else { throw "invalid data. Needs to be a string"; } } return true; } function getFormatPlacementVertical(modulesPerSide) { return [0, 1, 2, 3, 4, 5, 7, 8, modulesPerSide - 7, modulesPerSide - 6, modulesPerSide - 5, modulesPerSide - 4, modulesPerSide - 3, modulesPerSide - 2, modulesPerSide - 1]; } function getFormatPlacementHorizontal(modulesPerSide) { return [modulesPerSide - 1, modulesPerSide - 2, modulesPerSide - 3, modulesPerSide - 4, modulesPerSide - 5, modulesPerSide - 6, modulesPerSide - 7, modulesPerSide - 8, 7, 5, 4, 3, 2, 1, 0]; } function StateMachine(rgStates, fEnforceDifferentBegin, fEnforceDifferentEnd) { var _nCurrentMatchingPattern = 0; var _cBitsProcessed = 0; return { checkState: CheckState, reset: Reset }; function CheckState(curBit, nextBit) { _nCurrentMatchingPattern = _nCurrentMatchingPattern << 1 | curBit; _cBitsProcessed++; if ((_nCurrentMatchingPattern & g_rgBadPatternMask) == rgStates && _cBitsProcessed >= 11) { if (fEnforceDifferentBegin && FDifferentBeginning() || fEnforceDifferentEnd && FDifferentEnding(nextBit)) { Reset(); return true; } } return false; } function FDifferentEnding(nextBit) { if (nextBit == -1) return true; else if (nextBit != (rgStates & 1)) { return true; } return false; } function FDifferentBeginning() { if (_cBitsProcessed == 11) return true; if ((_nCurrentMatchingPattern >> 10 & 1) != (_nCurrentMatchingPattern >> 11 & 1)) { return true; } return false; } function Reset() { _nCurrentMatchingPattern = 0; _cBitsProcessed = 0; } } } var g_qrLoader = null; function onLoadQrCode(QRText, qRDiv) { qrtemp = QRText; QRDiv = qRDiv; g_qrLoader = QRLoader("qrCode", "qrCodeUrlText"); g_qrLoader.Render(); } function ChangeQrCodeSize(iSize) { g_qrLoader.ChangeSize(iSize); } function QRLoader(strElmQrCode, strElmDataToEncodeTitle) {
    var _strImgMinify = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAE2SURBVFhH7VXvBsJQHB0jeomI6GtfR6/Qy4w+RSwx9gDRp4joEXqI6A16hhExos7hLBnbandrxj0cdn9/zu937+4fx8LConPwfX8ArsEzmIAPfdM2UlgzQIEleAefOWRDgcLrA0Rd8KgiNzACp3LT78lGH2MY68ptDogFEr6CuctMn2IYW89KQGgIcmk5u9J/zBjFMsd8T0AkBDmjSKZSMFY5oUzVAZGLxCYylYKxyrnIVB0QiSXW43i2Oj2LqJy+chKOjQARkwZijo0AkdZ/QboJv95QVXJyAZF2jyEBIV7BnNEvFxE5l8scEDtIlLPjOffkoi97FX+y1iZ4JXNps0XKuJCEOSDGZU6fYz7F6XPMjTcG92CzTRQBhfhy7j4Kv6mQ/wAFt602QKDoptUGLCw6AMd5AR+ubApTgrTvAAAAAElFTkSuQmCC"; var _strImgMagnify = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFISURBVFhH7ZVdagJBEIQXBMFLBAJCXn0VcoUcJ08BWUUQPIDgUyAQyBFyiIA38AyCEBAErU9rFzXZDTprFmEKCpz+qe5pZ2eSiIiIm0OapnfiUPwSV+Lav7G1HXYdqEBP/BY3BaShvsOrg0Qb4oeLLMWx+Gg3/q5t+IghtmF3OCTWt/BcLBwzPscQW80kJHQvMlp2d1T8afC5gV7uQIxjyQk/ExIZiexobFOO3xoAxDpnZNPlkMjMYh2bcpQ00HHOzKbLIZGFxZqss6JFdE7LOSvWQZBISAML1kGQSO1/QXYIfxyokgYKc86GROr9DIGEuILZ0TkXEXy2KxwSe7cou+M779qF7/QqPmSlTXAlM9rTIn/xZa9QASTGmLPnmKc4e445eA/im3jdJsqgQrycrweFczrkf6CC01obACo6qbWBiIgbQJJsAd6EpD74rBS/AAAAAElFTkSuQmCC";
    var _strQrPageTemplate = "<div id='" + strElmQrCode + "'></div>"; var _qrCode = QRCodeEncoder(true); var _ModuleSize = 5; var _opts = { "moduleSize": _ModuleSize }; var _strData = decodeURIComponent(getUrlQrCodeData()); document.getElementById(QRDiv).innerHTML = _strQrPageTemplate; return { "Render": RenderQR, "ChangeSize": ChangeSize }; function RenderQR() { RenderQrElement(false); var strQRTitle = Strings.STS.L_QRCodeDescription.replace("{0}", _strData); (document.getElementById(strElmDataToEncodeTitle)).textContent = strQRTitle; } function ChangeSize(iSize) { if (iSize == -1) { _ModuleSize = _ModuleSize <= 5 ? _ModuleSize <= 2 ? 2 : _ModuleSize - 1 : _ModuleSize - 5; } else { _ModuleSize = _ModuleSize >= 50 ? 100 : _ModuleSize + 5; } _qrCode.moduleSize(_ModuleSize); RenderQrElement(true); return false; } function RenderQrElement(fForResize) {
        var data = fForResize ? null : _strData; var settings = fForResize ? null : _opts; var elm = _qrCode.generateElement(data, settings);
        var elmHost = document.getElementById(QRDiv); elmHost.innerHTML = ""; elmHost.appendChild(elm);
    } function GetWindowLocationHash() { var strUrl = window.location.href; var nHashPos = strUrl.indexOf('#'); nHashPos = nHashPos > 0 ? nHashPos : strUrl.length; return strUrl.substr(nHashPos); } function getUrlQrCodeData() { return qrtemp; }
}