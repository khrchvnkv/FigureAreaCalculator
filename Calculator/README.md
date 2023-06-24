# Geometry Area Calculator

### Площадь круга по радиусу
http://localhost:5147/geometry/area-size/?figureParams=1

### Площадь треугольника по 3 сторонам
http://localhost:5147/geometry/area-size/?figureParams=1&figureParams=1&figureParams=1

Тип фигуры определяется по количеству переданных параметров <br>
1 параметр - Круг<br>
3 параметра - Треугольник<br>

Опционально можно указать тип геометрии (круг или треугольник) если в дальнейшем количество параметров будет пересекаться для разных фигур

http://localhost:5147/geometry/area-size/?figureParams=1&geometryType=circle <br>
http://localhost:5147/geometry/area-size/?figureParams=1&figureParams=1&figureParams=1&geometryType=triangle <br>

Если количество или формат параметров некорректен будет выведен BadRequest
