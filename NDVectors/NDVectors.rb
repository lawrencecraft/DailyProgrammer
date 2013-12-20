class Vector
	attr_accessor :components

	def initialize initial
		if initial.is_a? String
			@components = initial.split(" ")[1..-1].map(&:to_f)
		elsif initial.is_a? Array
			@components = initial
		end
	end
	
	def euclidian_length
		Math.sqrt(@components.inject(0) {|total, value| total += value ** 2})
	end
	
	def unit_vector
		max_value = components.max
		Vector.new @components.map {|i| i / max_value}
	end
	
	def length
		@components.count
	end
	
	def dot_product other_vector
		if other_vector.length != length
			raise 'Vectors gotta be equal length bro'
		end
		
		@components.zip(other_vector.components).inject(0) {|t, v| t += v.first * v.last }
	end
	
	def to_s
		@components.join " "
	end
end

vectors = []

# Add vectors

Integer(gets.chomp).times do
	vectors.push(Vector.new gets.chomp)
end

Integer(gets.chomp).times do
	command = gets.chomp.split " "
	case command.shift
		when 'l'
			puts vectors[Integer(command.first)].euclidian_length
		when 'd'
			puts vectors[Integer(command.first)].dot_product vectors[Integer(command.last)]
		when 'n'
			puts vectors[Integer(command.first)].unit_vector.to_s
	end
end