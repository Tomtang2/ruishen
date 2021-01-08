/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : faultdiagnosis

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 30/11/2020 15:45:37
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for diagnosis_ttb_algorithm
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_algorithm`;
CREATE TABLE `diagnosis_ttb_algorithm`  (
  `ParameterClassify` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '参数所属类型',
  `ParameterName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '参数名称'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_algorithm
-- ----------------------------
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('箱型图', '上四分位');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('箱型图', '下四分位');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('箱型图', '中位数');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('箱型图', '四分位距');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('统计量', '方差');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('统计量', '均方根值');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('统计量', '歪度');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('统计量', '峭度');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('频谱图', '频率幅值');
INSERT INTO `diagnosis_ttb_algorithm` VALUES ('频谱图', '峰值频率');

-- ----------------------------
-- Table structure for diagnosis_ttb_channelparameterset
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_channelparameterset`;
CREATE TABLE `diagnosis_ttb_channelparameterset`  (
  `ChannelNumber` int(11) NOT NULL COMMENT '通道号，从1~8，共8个通道',
  `Switch` int(11) NOT NULL COMMENT '开/关，0代表未勾选，1代表勾选',
  `WheelAndAxle` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '轮轴编号',
  `Coupling` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '耦合方式，包络AC、DC、ICP',
  `Unit` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '单位',
  `Sensitivity` double(255, 2) NOT NULL COMMENT '灵敏度',
  `SensorRange` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '量程',
  `WheelSide` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '轮侧',
  `AnalysisBandWidth` int(255) NOT NULL COMMENT '分析带宽',
  `FrequencyGraph` int(255) NOT NULL COMMENT '谱线数',
  `Resolution` double(255, 7) NOT NULL COMMENT '分辨率',
  `WindowsFunction` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '窗函数类型，包括汉宁窗、汉明窗、矩形窗、布莱克曼窗',
  `AverageWay` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '平均方式类型，包括无平均、线性平均、指数平均、峰值保持',
  `AverageNumber` int(255) NULL DEFAULT NULL COMMENT '平均次数，只有线性平均和指数平均存在',
  `AcquisitionMode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '采集模式，包含连续采样和定时采样',
  `AcquisitionTime` double(255, 5) NULL DEFAULT NULL COMMENT '采样时间，只有定时采样需要设置',
  `SampleRate` int(255) NULL DEFAULT NULL COMMENT '采样率=分析带宽*2.5',
  `SampleNumber` int(255) NULL DEFAULT NULL COMMENT '采样点数=谱线数*2.5',
  PRIMARY KEY (`ChannelNumber`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_channelparameterset
-- ----------------------------
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (1, 1, '1#', 'ICP', 'mVolts/g', 97.00, '5V', '左', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (2, 1, '1#', 'ICP', 'mVolts/g', 102.00, '5V', '右', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (3, 1, '2#', 'ICP', 'mVolts/g', 101.00, '5V', '左', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (4, 1, '2#', 'ICP', 'mVolts/g', 102.00, '5V', '右', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (5, 1, '1#', 'ICP', 'mV/Pa', 40.90, '5V', '左', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (6, 1, '1#', 'ICP', 'mV/Pa', 42.60, '5V', '右', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (7, 1, '2#', 'ICP', 'mV/Pa', 43.50, '5V', '左', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);
INSERT INTO `diagnosis_ttb_channelparameterset` VALUES (8, 1, '2#', 'ICP', 'mV/Pa', 40.30, '5V', '右', 10240, 8192, 1.2500000, '不加窗', '无平均', 25, '定时采样', 60.00000, 25600, 20480);

-- ----------------------------
-- Table structure for diagnosis_ttb_character
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_character`;
CREATE TABLE `diagnosis_ttb_character`  (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `sampletime` datetime(0) NULL DEFAULT NULL,
  `VibrationOneChannelCharacterOne` blob NULL,
  `VibrationOneChannelCharacterTwo` blob NULL,
  `VibrationTwoChannelCharacterOne` blob NULL,
  `VibrationTwoChannelCharacterTwo` blob NULL,
  `VibrationThreeChannelCharacterOne` blob NULL,
  `VibrationThreeChannelCharacterTwo` blob NULL,
  `VibrationFourChannelCharacterOne` blob NULL,
  `VibrationFourChannelCharacterTwo` blob NULL,
  `characterNameOne` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `characterNameTwo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_dataindex
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_dataindex`;
CREATE TABLE `diagnosis_ttb_dataindex`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `Title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '头文件',
  `StartTime` datetime(0) NOT NULL COMMENT '开始时间',
  `EndTime` datetime(0) NOT NULL COMMENT '结束时间',
  `WheelStyleOne` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对型号1',
  `WheelStyleTwo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对型号2',
  `WheelSetSerialNumberOne` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号1',
  `WheelSetSerialNumberTwo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号1',
  `BearingStyleOne` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承型号1',
  `BearingStyleTwo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承型号2',
  `BearingOneLeftSerial` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承1左序列号',
  `BearingOneRightSerial` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承1右序列号',
  `BearingTwoLeftSerial` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承2左序列号',
  `BearingTwoRightSerial` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承2右序列号',
  `User` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作员',
  `TestBench` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '试验台',
  `Factory` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂',
  `Comment` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `SampleFrequency` int(255) NULL DEFAULT NULL COMMENT '采样频率',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_isticked
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_isticked`;
CREATE TABLE `diagnosis_ttb_isticked`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParameterNameTicked` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UpThresholdTicked` double(255, 5) NOT NULL,
  `DownThresholdTicked` double(255, 5) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_of1d1_noise
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_of1d1_noise`;
CREATE TABLE `diagnosis_ttb_of1d1_noise`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `DeviceNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备编号',
  `FactoryNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂编号',
  `MeasurePoint` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '测点',
  `SampleFrequency` int(255) NULL DEFAULT NULL COMMENT '采样频率',
  `SampleNumber` int(255) NULL DEFAULT NULL COMMENT '采样点数',
  `DataStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '数据状态',
  `DataTime` datetime(0) NULL DEFAULT NULL COMMENT '采样的当前时间',
  `DataValue` longblob NULL COMMENT '采样的数据',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_of1d1_noise_1
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_of1d1_noise_1`;
CREATE TABLE `diagnosis_ttb_of1d1_noise_1`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ProductModel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '产品型号',
  `WheelSetSerialNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号',
  `BearingType` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承类型',
  `BearingNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承编号',
  `TestBench` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '试验台',
  `Factory` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂',
  `TestTime` datetime(6) NULL DEFAULT NULL COMMENT '测试时间',
  `Users` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作员',
  `SamplingFrequency` int(255) NULL DEFAULT NULL COMMENT '采样频率',
  `SamplingDuration` double(255, 0) NULL DEFAULT NULL COMMENT '采样时长',
  `WindowType` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '窗类型',
  `AverageMode` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '平均方式',
  `DataValue` longblob NULL COMMENT '数据',
  `TestStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '测试状态',
  `ResultStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '结果状态',
  `StasticOne` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '统计量名称1',
  `StasticDataOne` longblob NULL COMMENT '统计量数据1',
  `StasticSecond` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '统计量名称2',
  `StasticDataSecond` longblob NULL COMMENT '统计量数据2',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_of1d1_vibration
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_of1d1_vibration`;
CREATE TABLE `diagnosis_ttb_of1d1_vibration`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `DeviceNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设备编号',
  `FactoryNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂编号',
  `MeasurePoint` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '测点',
  `SampleFrequency` int(255) NULL DEFAULT NULL COMMENT '采样频率',
  `SampleNumber` int(255) NULL DEFAULT NULL COMMENT '采样点数',
  `DataStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '数据状态',
  `DataTime` datetime(0) NULL DEFAULT NULL COMMENT '采样的当前时间',
  `DataValue` longblob NULL COMMENT '采样的数据',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_of1d1_vibration_1
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_of1d1_vibration_1`;
CREATE TABLE `diagnosis_ttb_of1d1_vibration_1`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ProductModel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '产品型号',
  `WheelSetSerialNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号',
  `BearingType` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承类型',
  `BearingNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承编号',
  `TestBench` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '试验台',
  `Factory` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂',
  `TestTime` datetime(6) NULL DEFAULT NULL COMMENT '测试时间',
  `Users` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作员',
  `SamplingFrequency` int(255) NULL DEFAULT NULL COMMENT '采样频率',
  `SamplingDuration` double(255, 0) NULL DEFAULT NULL COMMENT '采样时长',
  `WindowType` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '窗类型',
  `AverageMode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '平均方式',
  `DataValue` longblob NULL COMMENT '数据',
  `TestStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '测试状态',
  `ResultStatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '结果状态',
  `StasticOne` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '统计量名称1',
  `StasticDataOne` longblob NULL COMMENT '统计量数据1',
  `StasticSecond` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '统计量名称2',
  `StasticDataSecond` longblob NULL COMMENT '统计量数据2',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_originvalue
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_originvalue`;
CREATE TABLE `diagnosis_ttb_originvalue`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sampletime` datetime(0) NULL DEFAULT NULL,
  `channelone` longblob NULL,
  `channeltwo` longblob NULL,
  `channelthree` longblob NULL,
  `channelfour` longblob NULL,
  `channelfive` longblob NULL,
  `channelsix` longblob NULL,
  `channelseven` longblob NULL,
  `channeleight` longblob NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for diagnosis_ttb_parameterconfig
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_parameterconfig`;
CREATE TABLE `diagnosis_ttb_parameterconfig`  (
  `ChannelNumber` int(10) NOT NULL COMMENT '通道号',
  `PhysicalChannel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '物理通道名称',
  `MinimumValue` int(255) NOT NULL COMMENT '最小值',
  `MaximumValue` int(255) NOT NULL COMMENT '最大值',
  `SampleRate` int(255) NOT NULL COMMENT '采样频率',
  `SampleNumber` int(255) NOT NULL COMMENT '每通道采样点数',
  `Coupling` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '耦合方式',
  `Sensitivity` double(255, 2) NOT NULL COMMENT '传感器灵敏度',
  `Unit` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '灵敏度单位'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_parameterconfig
-- ----------------------------
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (1, 'cDAQ2Mod1/ai0', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (2, 'cDAQ2Mod1/ai1', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (3, 'cDAQ2Mod1/ai2', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (4, 'cDAQ2Mod1/ai3', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (5, 'cDAQ2Mod1/ai4', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (6, 'cDAQ2Mod1/ai5', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (7, 'cDAQ2Mod1/ai6', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');
INSERT INTO `diagnosis_ttb_parameterconfig` VALUES (8, 'cDAQ2Mod1/ai7', -5, 5, 20000, 5000, 'AC', 50.00, 'mV/g');

-- ----------------------------
-- Table structure for diagnosis_ttb_parts_bearing
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_parts_bearing`;
CREATE TABLE `diagnosis_ttb_parts_bearing`  (
  `Id` int(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `BearingDesignation` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承名称',
  `NewDomesticModel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '国内新型号',
  `OldDomesticModel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '国内旧型号',
  `InnerDiameter` int(255) NOT NULL COMMENT '轴承内径',
  `OuterDiameter` int(20) NOT NULL COMMENT '轴承外径',
  `Width` int(20) NOT NULL COMMENT '轴承宽度',
  `Cr` double(255, 1) NULL DEFAULT NULL COMMENT '轴承基本额定动载荷',
  `Cor` double(255, 1) NULL DEFAULT NULL COMMENT '轴承基本额定静载荷',
  `Grease` int(20) NULL DEFAULT NULL COMMENT '轴承脂润滑转速',
  `Oil` int(20) NULL DEFAULT NULL COMMENT '轴承油润滑转速',
  `Mass` double(255, 3) NULL DEFAULT NULL COMMENT '轴承质量',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 36 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_parts_bearing
-- ----------------------------
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (2, '深沟球轴承', '61802', '1000802', 15, 24, 5, 2.1, 1.3, 22000, 30000, 0.007);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (3, '调心球轴承', '1203K+H203', '11203', 17, 47, 14, 3.1, 4.2, 12000, 36000, 0.004);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (4, '圆锥滚子轴承', 'HK', '113000', 15, 45, 14, NULL, NULL, NULL, 23000, 0.003);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (5, '深沟球轴承', '6300', '300', 10, 35, 11, 7.7, 3.5, 18000, 24000, 0.053);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (6, '深沟球轴承', '61801', '1000801', 12, 21, 5, 1.9, 1.0, 24000, 32000, 0.006);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (7, '深沟球轴承', '61901', '1000901', 12, 24, 6, 2.9, 1.5, 22000, 28000, 0.011);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (8, '深沟球轴承', '16001', '7000101', 12, 28, 7, 5.1, 2.4, 20000, 26000, 0.024);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (9, '深沟球轴承', '6001', '101', 12, 28, 8, 5.1, 2.4, 20000, 26000, 0.022);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (10, '深沟球轴承', '6201', '201', 12, 32, 10, 6.8, 3.0, 19000, 24000, 0.037);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (11, '深沟球轴承', '61902', '1000902', 15, 28, 7, 4.3, 2.3, 20000, 26000, 0.017);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (12, '深沟球轴承', '16002', '7000102', 15, 32, 8, 5.6, 2.8, 19000, 24000, 0.025);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (13, '深沟球轴承', '6002', '102', 15, 32, 9, 5.6, 2.8, 19000, 24000, 0.030);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (14, '深沟球轴承', '6202', '202', 15, 35, 11, 7.7, 3.7, 18000, 22000, 0.045);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (15, '深沟球轴承', '6302', '302', 15, 42, 13, 11.5, 5.4, 16000, 20000, 0.082);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (16, '圆锥滚子轴承', '30202', '7202E', 15, 35, 11, 14.9, 13.4, 12000, 16000, 0.053);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (17, '圆锥滚子轴承', '30340', '7340E', 200, 420, 80, 1120.0, 1450.0, 820, 1100, 53.500);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (18, '圆锥滚子轴承', '30302', '7302E', 15, 42, 13, 22.8, 21.5, 9000, 12000, 0.094);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (19, '圆锥滚子轴承', '30203', '7203E', 17, 40, 12, 20.8, 21.8, 9000, 12000, 0.079);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (21, '圆锥滚子轴承', '32303', '7603E', 17, 47, 19, 31.9, 29.9, 9400, 13000, 0.170);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (22, '圆锥滚子轴承', '32904', '2007904E', 20, 37, 12, 13.2, 17.5, 9500, 13000, 0.056);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (23, '圆锥滚子轴承', '32004', '2007104E', 20, 42, 15, 25.0, 28.2, 8500, 11000, 0.095);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (24, '圆锥滚子轴承', '30204', '7204E', 20, 47, 14, 28.2, 30.5, 8000, 10000, 0.125);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (25, '圆锥滚子轴承', '30304', '7304E', 20, 52, 15, 30.5, 28.4, 8300, 11000, 0.170);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (26, '圆锥滚子轴承', '32304', '7604E', 20, 52, 21, 42.8, 46.2, 7500, 9500, 0.230);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (27, '调心球轴承', '1204K+H204', '11204', 20, 47, 40, 9.9, 2.6, 14000, 17000, 0.191);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (29, '调心球轴承', '1206K+H206', '11206', 30, 62, 48, 15.6, 4.7, 9900, 12000, 0.360);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (30, '调心球轴承', '1207K+H207', '11207', 35, 72, 52, 15.8, 5.1, 8500, 10000, 0.556);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (31, '调心球轴承', '1208K+H208', '11208', 40, 82, 56, 19.2, 6.5, 7500, 9200, 0.733);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (32, '调心球轴承', '1209K+H209', '11209', 45, 85, 58, 21.8, 7.3, 7000, 8500, 0.793);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (33, '调心球轴承', '1210K+H210', '11210', 50, 92, 58, 22.7, 8.1, 6500, 7900, 0.875);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (34, '调心球轴承', '1211K+H211', '11211', 55, 100, 60, 26.8, 10.0, 5800, 7100, 1.160);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (35, '圆锥滚子轴承', '353130B', NULL, 150, 250, 206, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `diagnosis_ttb_parts_bearing` VALUES (36, '圆锥滚子轴承', '353130A', NULL, 150, 250, 275, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for diagnosis_ttb_productstyle
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_productstyle`;
CREATE TABLE `diagnosis_ttb_productstyle`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `SetTitle` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '标题',
  `SelectedWheel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对选择',
  `WheelModel1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对型号1',
  `WheelSetSerialNumber1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号1',
  `BearModel1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承型号1',
  `BearSerialLeft1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承序列号左1',
  `BearSerialRight1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承序列号右1',
  `WheelModel2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对型号2',
  `WheelSetSerialNumber2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轮对序列号2',
  `BearModel2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承型号2',
  `BearSerialLeft2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承序列号左2',
  `BearSerialRight2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '轴承序列号右2',
  `User` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作者',
  `TestBench` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '试验台',
  `FactoryNumber` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '工厂号',
  `Comment` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_productstyle
-- ----------------------------
INSERT INTO `diagnosis_ttb_productstyle` VALUES (1, '双号', '双轮对', 'NS11', '0011', '353130A', 'MD12', 'MD13', 'NS12', '0012', '353130B', 'MD14', 'MD15', '张三', '货轮试验台', '重庆长征重工', '。。。');

-- ----------------------------
-- Table structure for diagnosis_ttb_sensorinformation
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_sensorinformation`;
CREATE TABLE `diagnosis_ttb_sensorinformation`  (
  `id` int(11) NOT NULL,
  `sensitivity` int(11) NULL DEFAULT NULL,
  `sensor_range` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `serial_number` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `type` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_sensorinformation
-- ----------------------------
INSERT INTO `diagnosis_ttb_sensorinformation` VALUES (1, 100, '0-10', 'HD-YD-216', '加速度');
INSERT INTO `diagnosis_ttb_sensorinformation` VALUES (2, 100, '0-5', 'HD-YD-216', '加速度');
INSERT INTO `diagnosis_ttb_sensorinformation` VALUES (3, 100, '0-10', 'HD-CD-224', '速度');
INSERT INTO `diagnosis_ttb_sensorinformation` VALUES (4, 200, '0-5', 'HD-WY-220', '位移');

-- ----------------------------
-- Table structure for diagnosis_ttb_user
-- ----------------------------
DROP TABLE IF EXISTS `diagnosis_ttb_user`;
CREATE TABLE `diagnosis_ttb_user`  (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of diagnosis_ttb_user
-- ----------------------------
INSERT INTO `diagnosis_ttb_user` VALUES (1, 'ttb', 'ttb1996');
INSERT INTO `diagnosis_ttb_user` VALUES (2, 'admin', 'admin');

-- ----------------------------
-- Table structure for sensor_information
-- ----------------------------
DROP TABLE IF EXISTS `sensor_information`;
CREATE TABLE `sensor_information`  (
  `id` int(11) NOT NULL,
  `sensitivity` int(11) NULL DEFAULT NULL,
  `sensor_range` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `serial_number` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `type` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sensor_information
-- ----------------------------
INSERT INTO `sensor_information` VALUES (1, 100, '0-10', 'HD-YD-216', '加速度');
INSERT INTO `sensor_information` VALUES (2, 100, '0-5', 'HD-YD-216', '加速度');

SET FOREIGN_KEY_CHECKS = 1;
