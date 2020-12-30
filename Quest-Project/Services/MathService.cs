using Quest_Project.Models;

namespace Quest_Project.Services
{
  public class MathService : IMathService
  {
    /// <inheritdoc/>
    public void Multiply(MathMultiplyOperationModel operationModel)
    {
      operationModel.Result = operationModel.Multiplicand * operationModel.Multiplier;
    }
  }
}