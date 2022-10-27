CREATE PROCEDURE [dbo].[Update]

      @p_id int,
	  @p_name varchar(50),
	  @p_cost int
	  

AS

BEGIN

    

      UPDATE  Pizza SET Food_name = @p_name,Cost=@p_cost
	

      WHERE Order_id=@p_id

END

CREATE PROCEDURE [dbo].sp_Delete
	@p_id int
	
AS
	Delete from Pizza
	where Order_id=@p_id;
RETURN 0

Create PROCEDURE [dbo].sp_Find
	 @p_id int,
	  @p_name varchar(20) output,
	  @p_cost int output
	  

	

AS
	SELECT
	@p_name=Food_name,@p_cost=Cost
	from Pizza	where Order_id=@p_id;

RETURN 0