
class Particle
	attr_accessor :x, :y, :mass
	
	def distance other_particle
		deltaX = other_particle.x - @x
		deltaY = other_particle.y - @y
		Math.sqrt(deltaX ** 2 + deltaY ** 2)
	end
	
	def force other_particle
		other_particle.mass * @mass / (distance(other_particle) ** 2)
	end
	
	def initialize particleString
		floatValueArray = particleString.split(" ").map {|const| Float(const)}
		@mass, @x, @y = floatValueArray
	end
end

def get_particle
	Particle.new gets.chomp
end

particle1 = get_particle
particle2 = get_particle

puts particle1.force(particle2)