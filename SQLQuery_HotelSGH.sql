use HotelSGH;




DROP TRIGGER  Pedido_Update_Insert;
DROP TRIGGER  DetallePedido_Update_Insert;


SELECT name
FROM sys.triggers
WHERE parent_class_desc = 'OBJECT_OR_COLUMN'; -- Puedes ajustar esto según tus necesidades



CREATE TRIGGER DetallePedido_Update_Insert
ON DetallePedido
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Update
    IF EXISTS (SELECT * FROM inserted i INNER JOIN deleted d ON i.Id = d.Id WHERE i.NombreProducto <> d.NombreProducto OR i.CantidadPedida <> d.CantidadPedida OR i.Subtotal <> d.Subtotal OR i.Impuestos <> d.Impuestos OR i.Total <> d.Total OR i.Producto_Id <> d.Producto_Id OR i.Pedido_Id <> d.Pedido_Id)
    BEGIN
        INSERT INTO DetallePedidoHistorico (NombreProducto, CantidadPedida, Subtotal, Impuestos, Total, ProductoId, PedidoId, FechaModificacion, Operacion, DetallePedidoId)
        SELECT i.NombreProducto, i.CantidadPedida, i.Subtotal, i.Impuestos, i.Total, i.Producto_Id, i.Pedido_Id, GETDATE(), 'Modificar', i.Id
        FROM inserted i
        INNER JOIN deleted d ON i.Id = d.Id
        WHERE i.NombreProducto <> d.NombreProducto OR i.CantidadPedida <> d.CantidadPedida OR i.Subtotal <> d.Subtotal OR i.Impuestos <> d.Impuestos OR i.Total <> d.Total OR i.Producto_Id <> d.Producto_Id OR i.Pedido_Id <> d.Pedido_Id;
    END

    -- Insert
    ELSE IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO DetallePedidoHistorico (NombreProducto, CantidadPedida, Subtotal, Impuestos, Total, ProductoId, PedidoId, FechaModificacion, Operacion, DetallePedidoId)
        SELECT i.NombreProducto, i.CantidadPedida, i.Subtotal, i.Impuestos, i.Total, i.Producto_Id, i.Pedido_Id, GETDATE(), 'Crear', i.Id
        FROM inserted i;
    END

    -- Delete
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO DetallePedidoHistorico (NombreProducto, CantidadPedida, Subtotal, Impuestos, Total, ProductoId, PedidoId, FechaModificacion, Operacion, DetallePedidoId)
        SELECT d.NombreProducto, d.CantidadPedida, d.Subtotal, d.Impuestos, d.Total, d.Producto_Id, d.Pedido_Id, GETDATE(), 'Eliminar', d.Id
        FROM deleted d;
    END
END;


CREATE TRIGGER Pedido_Update_Insert
ON Pedido
AFTER UPDATE, INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Update
    IF EXISTS (SELECT * FROM inserted i INNER JOIN deleted d ON i.Id = d.Id WHERE i.NroPedido <> d.NroPedido OR i.Estado <> d.Estado OR i.Subtotal <> d.Subtotal OR i.Impuestos <> d.Impuestos OR i.Total <> d.Total OR i.Reserva_Id <> d.Reserva_Id OR i.Factura_Id <> d.Factura_Id)
    BEGIN
        INSERT INTO PedidoHistorico (NroPedido, Estado, FechaCreacion, Subtotal, Impuestos, Total, ReservaId, FacturaId, FechaModificacion, Operacion, PedidoId)
        SELECT i.NroPedido, i.Estado, i.FechaCreacion, i.Subtotal, i.Impuestos, i.Total, i.Reserva_Id, i.Factura_Id, GETDATE(), 'Modificar', i.Id
        FROM inserted i
        INNER JOIN deleted d ON i.Id = d.Id
        WHERE i.NroPedido <> d.NroPedido OR i.Estado <> d.Estado OR i.Subtotal <> d.Subtotal OR i.Impuestos <> d.Impuestos OR i.Total <> d.Total OR i.Reserva_Id <> d.Reserva_Id OR i.Factura_Id <> d.Factura_Id;
    END

    -- Insert
    ELSE IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO PedidoHistorico (NroPedido, Estado, FechaCreacion, Subtotal, Impuestos, Total, ReservaId, FacturaId, FechaModificacion, Operacion, PedidoId)
        SELECT i.NroPedido, i.Estado, i.FechaCreacion, i.Subtotal, i.Impuestos, i.Total, i.Reserva_Id, i.Factura_Id, GETDATE(), 'Crear', i.Id
        FROM inserted i;
    END

    -- Delete
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO PedidoHistorico (NroPedido, Estado, FechaCreacion, Subtotal, Impuestos, Total, ReservaId, FacturaId, FechaModificacion, Operacion, PedidoId)
        SELECT d.NroPedido, d.Estado, d.FechaCreacion, d.Subtotal, d.Impuestos, d.Total, d.Reserva_Id, d.Factura_Id, GETDATE(), 'Eliminar', d.Id
        FROM deleted d;
    END
END;
