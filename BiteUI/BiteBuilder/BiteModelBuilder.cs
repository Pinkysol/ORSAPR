﻿using Kompas6Constants3D;
using Kompas6API5;
using BiteSDK;
using System;
using System.Collections.Generic;

namespace BiteBuilder
{
    //TODO: XML
    /// <summary>
    /// публичный класс отвечающий за 
    /// построение проектируемой 3D-модели стеллажа
    /// </summary>
    public class BiteModelBuilder
    {
        //TODO: XML
        /// <summary>
        /// приватный параметр, реализующий связь между API и Компас-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// публичный метод, отвечающий за
        /// окончательную сборку проектируемой 3D-модели биты
        /// </summary>
        /// <param name="parameters">переменная хранящая в себе
        /// текущие значения для построения 3D-модели биты </param>
        public void Assembly(BiteParameters parameters)
        {
            _connector = new KompasConnector();
            _connector.GetNewPart();
            BuildCylinder(parameters.BiteLength, parameters.Diameter);
            BuildHexagon(parameters.LengthOfStraightConnector, parameters.Diameter);
            //TODO: RSDN
            BuildNozzle(parameters.Diameter, parameters.BiteLength, 
                parameters.LengthOfStraightConnector, parameters.LengthOfStraight, 
                parameters.WidthOfAdjoiningPart);
        }
        /// <summary>
        /// приватный метод, отвечающий за
        /// построение цилиндра проектируемой 3D-модели биты 
        /// </summary>
        /// <param name="biteLength">длина биты</param>
        /// <param name="diameter">диаметр</param>
        /// для полок/пространства от пола до нижней полки</param>
        private void BuildCylinder(double biteLength, double diameter)
        {
            var circleCenter = new double[] { 0, 0 };
            var circleRad = diameter / 2;
            //Создание эскиза и построение в нем окружности
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2d = (ksDocument2D)sketchDef.BeginEdit();
            doc2d.ksCircle(circleCenter[0], circleCenter[1], circleRad, 1);
            sketchDef.EndEdit();
            //Параметры выдавливания
            var lengthExtrusion = biteLength / 5;
            CreateExtrusion(sketchDef, lengthExtrusion, thin: false, side: true);
        }
        /// <summary>
        /// приватный метод, отвечающий за построение
        /// шестиугольной соединительной части 
        /// проектируемой 3D-модели биты
        /// </summary>
        /// <param name="lengthOfStraightConnector">длина прямой 
        /// соединительной части</param>
        /// <param name="diameter">диаметр</param>
        /// для полок/пространства от пола до нижней полки</param>
        private void BuildHexagon(double lengthOfStraightConnector, double diameter)
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            ksDocument2D doc2D = (ksDocument2D)sketchDef.BeginEdit();
            var radius = (diameter / 2)/ Math.Cos(30 * Math.PI / 180);
            var x = radius;
            var y = 0.0;
            var angle = 60 * Math.PI / 180;
            var points = new List<Point>();
            points.Add(new Point(x, y));
            for (var i = 1; i <= 5; i++)
            {
                points.Add(new Point(radius * Math.Cos(i * angle),
                    radius * Math.Sin(i * angle)));
            }

            for (var i = 0; i < points.Count; i++)
            {
                var nextIndex = i + 1;
                if (i == points.Count - 1)
                {
                    nextIndex = 0;
                }
                doc2D.ksLineSeg(points[i].X, points[i].Y,
                    points[nextIndex].X, points[nextIndex].Y, 1);
            }


            sketchDef.EndEdit();
            //Параметры выдавливания
            var lengthExtrusion = lengthOfStraightConnector;
            CreateExtrusion(sketchDef, lengthExtrusion, thin: false, side: false);
        }

        /// <summary>
        /// приватный метод, отвечающий за построение
        /// шестиугольной соединительной части 
        /// проектируемой 3D-модели биты
        /// </summary>
        /// <param name="diameter">диаметр</param>
        /// <param name="lengthOfStraightConnector">длина прямой 
        /// соединительной части</param>
        /// <param name="lengthOfStraight">длина прямой части</param>
        /// <param name="widthOfAdjoiningPart">ширина прилегающей 
        /// части носика</param>
        /// для полок/пространства от пола до нижней полки</param>
        private void BuildNozzle(double diameter, double biteLength, 
            double lengthOfStraightConnector, double lengthOfStraight, 
            double widthOfAdjoiningPart)
        {
            var radius = diameter / 2;
            var x = 0.5;
            var y = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(x, 2));
            var points = new List<Point>
            {
                new Point(-x, y),
                new Point(x, -y),
                new Point(-y, x),
                new Point(y, -x),
            };
            var plane = CreateOffsetPlane(biteLength / 5,
                Obj3dType.o3d_planeXOY);
            var sketchDef = CreateSketch(offsetPlane: plane);
            var doc2d = (ksDocument2D)sketchDef.BeginEdit();
            for (var i = 0; i < points.Count; i += 2)
            {
                CreateRectangle(points[i], points[i + 1], doc2d);
            }
            sketchDef.EndEdit();

            var lengthExtrusion = biteLength - (biteLength / 5 + lengthOfStraightConnector);
            CreateExtrusion(sketchDef, lengthExtrusion, thin: false, side: true);

            
            double triangleLeg = Math.Sqrt(Math.Pow(lengthOfStraight, 2) 
                - Math.Pow(radius - widthOfAdjoiningPart, 2));
            double shiftVar = biteLength / 5 + lengthExtrusion;
            var pointsTriangle = new List<Point>
            {
                new Point(widthOfAdjoiningPart, 0 - shiftVar),
                new Point(y,0 - shiftVar),
                new Point(y,triangleLeg - shiftVar),
                new Point(0 - shiftVar,widthOfAdjoiningPart),
                new Point(0 - shiftVar, y),
                new Point(triangleLeg - shiftVar,y),
            };

            sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            doc2d = (ksDocument2D)sketchDef.BeginEdit();
            CreateTrianglesXO(pointsTriangle[0], pointsTriangle[1], pointsTriangle[2], doc2d);
            sketchDef.EndEdit();
            CutNozzle(sketchDef);

            sketchDef = CreateSketch(Obj3dType.o3d_planeYOZ);
            doc2d = (ksDocument2D)sketchDef.BeginEdit();
            CreateTrianglesYO(pointsTriangle[3], pointsTriangle[4], pointsTriangle[5],  doc2d);
            sketchDef.EndEdit();
            CutNozzle(sketchDef);
        }

        /// <summary>
        /// приватный метод, предназначенный для 
        /// выдавливания срезания проектируемой 3D-модели 
        /// носика биты
        /// </summary>
        /// <param name="sketchDef">эскиз по которому будет
        /// производиться выдавливание</param>
        private void CutNozzle(ksSketchDefinition sketchDef) 
        {
            bool side = true;
            for (int i = 0; i < 2; i++)
            {
                CreateСutExtrusion(sketchDef, side);
                side = false;
            }
        }

        /// <summary>
        /// приватный метод, отвечающий за 
        /// создание эскиза на выбранной плоскости
        /// </summary>
        /// <param name="planeType">вариант плоскости</param>
        /// <returns></returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType
        = Obj3dType.o3d_planeXOY,
        ksPlaneOffsetDefinition offsetPlane = null)
        {
            var plane = (ksEntity)_connector.Part.GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)_connector.Part.
                NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition ksSketch = (ksSketchDefinition)sketch.
                GetDefinition();

            if (offsetPlane != null)
            {
                ksSketch.SetPlane(offsetPlane);
                sketch.Create();
                return ksSketch;
            }
            ksSketch.SetPlane(plane);
            sketch.Create();
            return ksSketch;
        }

        /// </summary>
        /// Метод для выполнения выдавливания
        /// </summary>
        /// <param name="sketchDef">Эскиз по которому будет
        /// производиться выдавливание</param>
        /// <param name="lenght">Расстояние выдавливания</param>
        /// <param name="side">Направление выдавливания</param>
        private void CreateExtrusion(ksSketchDefinition sketchDef,
            double lenght, bool side = true, bool thin = true, double angle = 0)
        {
            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion;
            var extrusionEntity = (ksEntity)_connector.Part.
                NewEntity((short)type);
            var extrusionDef = (ksBossExtrusionDefinition)
                extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side,
                (short)End_Type.etBlind, lenght, angle, false);
            extrusionDef.directionType = side ?
                (short)Direction_Type.dtNormal :
                (short)Direction_Type.dtReverse;
            extrusionDef.SetThinParam(thin,
                (short)Direction_Type.dtNormal, 0.5, 1);
            extrusionDef.SetSketch(sketchDef);
            extrusionEntity.Create();
        }

        /// </summary>
        /// Метод для выполнения выдавливания с обрезкой
        /// </summary>
        /// <param name="sketchDef">Эскиз по которому будет
        /// производиться выдавливание</param>
        /// <param name="side">Направление выдавливания</param>
        private void CreateСutExtrusion(ksSketchDefinition sketchDef,
           bool side = false)
        {

            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_cutExtrusion;
            var extrudeEntity =
                (ksEntity)_connector.Part.NewEntity((short)type);
            var extrudeDef =
                (ksCutExtrusionDefinition)extrudeEntity.GetDefinition();
            extrudeDef.SetSideParam(side, (short)End_Type.etThroughAll);

            extrudeDef.directionType = side ?
                (short)Direction_Type.dtNormal :
                (short)Direction_Type.dtReverse;

            extrudeDef.SetSketch(sketchDef);

            extrudeEntity.Create();

        }
        /// </summary>
        /// Метод для создания эскиза треугольника
        /// </summary>
        /// <param name="point1">первый список точек</param>
        /// <param name="point2">второй список точек</param>
        /// <param name="document2D">эскиз по которому
        /// будет производиться выдавливание</param>
        private void CreateRectangle(Point point1,
            Point point2, ksDocument2D document2D)
        {
            document2D.ksLineSeg(point1.X, -point1.Y,
                point2.X, -point1.Y, 1);
            document2D.ksLineSeg(point2.X, -point1.Y,
                point2.X, -point2.Y, 1);
            document2D.ksLineSeg(point1.X, -point2.Y,
                point2.X, -point2.Y, 1);
            document2D.ksLineSeg(point1.X, -point1.Y,
                point1.X, -point2.Y, 1);
        }

        /// </summary>
        /// Метод для создания эскиза треугольника на оси OX
        /// </summary>
        /// <param name="point1">первый список точек</param>
        /// <param name="point2">второй список точек</param>
        /// <param name="document2D">эскиз по которому
        /// будет производиться выдавливание</param>
        private void CreateTrianglesXO(Point point1,
    Point point2, Point point3 ,ksDocument2D document2D)
        {
            document2D.ksLineSeg(point1.X, point1.Y,
                point2.X, point2.Y, 1);
            document2D.ksLineSeg(point2.X, point2.Y,
               point3.X, point3.Y, 1);
            document2D.ksLineSeg(point3.X, point3.Y,
               point1.X, point1.Y, 1);
            document2D.ksLineSeg(-point1.X, point1.Y,
                -point2.X, point2.Y, 1);
            document2D.ksLineSeg(-point2.X, point2.Y,
               -point3.X, point3.Y, 1);
            document2D.ksLineSeg(-point3.X, point3.Y,
               -point1.X, point1.Y, 1);
        }

        /// </summary>
        /// Метод для создания эскиза треугольника на оси OY
        /// </summary>
        /// <param name="point1">первый список точек</param>
        /// <param name="point2">второй список точек</param>
        /// <param name="document2D">эскиз по которому
        /// будет производиться выдавливание</param>
        private void CreateTrianglesYO(Point point1,
    Point point2, Point point3, ksDocument2D document2D)
        {
            document2D.ksLineSeg(point1.X, point1.Y,
                point2.X, point2.Y, 1);
            document2D.ksLineSeg(point2.X, point2.Y,
               point3.X, point3.Y, 1);
            document2D.ksLineSeg(point3.X, point3.Y,
               point1.X, point1.Y, 1);
            document2D.ksLineSeg(point1.X, -point1.Y,
                point2.X, -point2.Y, 1);
            document2D.ksLineSeg(point2.X, -point2.Y,
               point3.X, -point3.Y, 1);
            document2D.ksLineSeg(point3.X, -point3.Y,
               point1.X, -point1.Y, 1);
        }
        /// <summary>
        /// Метод строит отложенную плоскость от
        /// одной из базовых с определенным отступом
        /// </summary>
        /// <param name="offset">Отступ отложенной плоскости</param>
        /// <param name="type">Одна из трех базовых плоскостей</param>
        /// <returns></returns>
        private ksPlaneOffsetDefinition CreateOffsetPlane(double offset, Obj3dType type)
        {
            var plane = (ksEntity)_connector.Part.GetDefaultEntity((short)type);
            var newEntity = (ksEntity)
                _connector.Part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition offsetPlane = 
                (ksPlaneOffsetDefinition)newEntity.GetDefinition();
            offsetPlane.SetPlane(plane);
            offsetPlane.offset = offset;
            newEntity.Create();

            return offsetPlane;
        }

    }

}
