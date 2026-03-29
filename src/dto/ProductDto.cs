namespace test_net.src.dto;

public record CreateProductDto(string Name, decimal Price);
public record ProductDto(int Id, string Name, decimal Price);
